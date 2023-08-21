using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface ICategoryDataService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    Task<CategoryDto?> GetCategoryAsync(Guid id);
    Task<bool> AddCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(Guid id);
}
