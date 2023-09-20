using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.AspNetCore.Http;

namespace CookBlog.Api.Core.Repositories;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<Post?> GetAsync(PostId id);
    Task<bool> AnyAsync(PostId id);
    void DeleteAsync(Post post);
    Task<ImagePath?> GetImagePathAsync(PostId postId);
    Task<ImagePath> ChangeImagePathAsync(IFormFile file);
}
