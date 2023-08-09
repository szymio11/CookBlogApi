using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Application.Queries;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

internal sealed class GetCategoryHandler : IQueryHandler<GetCategory, CategoryDto>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetCategoryHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<CategoryDto> HandleAsync(GetCategory query)
    {
        var categoryId = new CategoryId (query.CategoryId);
        var category = await _dbContext.Categories
            .AsNoTracking()
            .Select(Extensions.AsCategoryDto())
            .SingleOrDefaultAsync(c => c.Id == categoryId.Value);

        if (category is null) 
        {
            throw new NotFoundCategoryException(categoryId);
        }

        return category;
    }
}
