using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface ICategoryDataService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    Task<CategoryDto?> GetCategoryAsync(Guid id);
    Task<bool> AddCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategory(Guid id, CategoryDto categoryDto);
    Task DeleteCategoryAsync(Guid id);
}
