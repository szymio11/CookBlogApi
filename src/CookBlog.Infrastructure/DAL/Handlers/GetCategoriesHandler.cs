using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using CookBlog.Api.Core.Repositories;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

public sealed class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query)
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.Select(x => new CategoryDto { Id = x.Id, FullName = x.FullName });
    }
}
