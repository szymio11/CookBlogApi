using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Application.Queries;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

public sealed class GetPostHandler : IQueryHandler<GetPost, PostDto>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetPostHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<PostDto> HandleAsync(GetPost query)
    {
        var postId = new PostId(query.PostId);
        var post = await _dbContext.Posts
            .AsNoTracking()
            .Select(Extensions.AsPostDto())
            .SingleOrDefaultAsync(p => p.Id == postId.Value);

        if (post is null) 
        {
            throw new NotFoundPostException(postId);
        }

        return post;
    }
}
