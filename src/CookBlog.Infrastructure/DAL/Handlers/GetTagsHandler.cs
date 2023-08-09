using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

public sealed class GetTagsHandler : IQueryHandler<GetTags, IEnumerable<TagDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetTagsHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<TagDto>> HandleAsync(GetTags query) 
        => await _dbContext.Tags
            .AsNoTracking()
            .Select(Extensions.AsTagDto())
            .ToListAsync();
}
