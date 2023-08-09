using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetAsync(CategoryId id);
    Task AddAsync(Category category);
    void DeleteAsync(Category category);
    Task<bool> AnyAsync(CategoryId id);
}
