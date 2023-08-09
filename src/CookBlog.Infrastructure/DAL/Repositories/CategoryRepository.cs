using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Repositories;

internal sealed class CategoryRepository : ICategoryRepository
{
    private readonly DbSet<Category> _categories;

    public CategoryRepository(MyCookBlogDbContext dbContext) 
        => _categories = dbContext.Categories;

    public async Task<IEnumerable<Category>> GetAllAsync() 
        => await _categories
        .Include(c => c.Posts)
        .ToListAsync();

    public async Task<Category?> GetAsync(CategoryId id) 
        => await _categories
        .Include(c => c.Posts)
        .SingleOrDefaultAsync(c => c.Id == id);

    public async Task<bool> AnyAsync(CategoryId id)
        => await _categories.AnyAsync(p => p.Id == id);

    public async Task AddAsync(Category category)
    {
        await _categories.AddAsync(category);
    }

    public void DeleteAsync(Category category)
    {
        _categories.Remove(category);
    }

}
