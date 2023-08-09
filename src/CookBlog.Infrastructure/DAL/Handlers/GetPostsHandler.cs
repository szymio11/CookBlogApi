using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

public sealed class GetPostsHandler : IQueryHandler<GetPosts, IEnumerable<PostDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetPostsHandler(MyCookBlogDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<IEnumerable<PostDto>> HandleAsync(GetPosts query)
        => await _dbContext.Posts
            .AsNoTracking()
            .Select(Extensions.AsPostDto())
            .ToListAsync();
}
