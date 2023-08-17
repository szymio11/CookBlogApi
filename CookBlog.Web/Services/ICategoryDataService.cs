using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Web.Services
{
    public interface ICategoryDataService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetAsync(CategoryId id);
        Task AddAsync(Category category);
        void DeleteAsync(Category category);
        Task<bool> AnyAsync(CategoryId id);
    }
}
