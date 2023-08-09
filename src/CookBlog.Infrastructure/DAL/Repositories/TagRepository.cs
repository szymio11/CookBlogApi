using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Repositories;

internal sealed class TagRepository : ITagRepository
{
    private readonly DbSet<Tag> _tags;

    public TagRepository(MyCookBlogDbContext dbContext)
        => _tags = dbContext.Tags;

    public async Task AddAsync(Tag tag)
    {
        await _tags.AddAsync(tag);
    }

    public void DeleteAsync(Tag tag)
    {
        _tags.Remove(tag);
    }

    public async Task<Tag?> GetAsync(TagId id)
        => await _tags
        .Include(t => t.Posts)
        .SingleOrDefaultAsync(t => t.Id == id);

    public async Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids)
    {
        var tag = await _tags.Where(t => ids.Contains(t.Id)).ToListAsync();
        return tag;
    }
}
