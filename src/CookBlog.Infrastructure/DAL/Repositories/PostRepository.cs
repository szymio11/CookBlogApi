using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CookBlog.Api.Infrastructure.DAL.Repositories;

internal sealed class PostRepository : IPostRepository
{
    private readonly DbSet<Post> _posts;
    private readonly IHostEnvironment _environment;

    public PostRepository(MyCookBlogDbContext dbContext,
        IHostEnvironment environment)
    {
        _posts = dbContext.Posts;
        _environment = environment;
    }

    public async Task AddAsync(Post post)
    {
        await _posts.AddAsync(post);
    }

    public void DeleteAsync(Post post)
    {
        _posts.Remove(post);
    }

    public async Task<bool> AnyAsync(PostId id) 
        => await _posts.AnyAsync(p => p.Id == id);

    public async Task<Post?> GetAsync(PostId id)
        => await _posts
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .SingleOrDefaultAsync(p => p.Id == id);

    public async Task<ImagePath?> GetImagePathAsync(PostId postId)
        => await _posts.Where(p => p.Id == postId)
            .Select(p => p.ImagePath)
            .FirstOrDefaultAsync();

    public async Task<ImagePath> ChangeImagePathAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new Exception("upload a file");

        var fileName = file.FileName;
        var extension = Path.GetExtension(fileName);

        string[] allowedExtensions = { ".jpg", ".png", ".bmp" };

        if (!allowedExtensions.Contains(extension))
            throw new Exception("FileContents is not a valid image");

        var newFileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Images", newFileName);

        using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        {
            await file.CopyToAsync(fileStream);
        }

        return filePath;
    }
}
