using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Repositories;

public interface ITagRepository
{
    Task AddAsync(Tag tag);
    Task<Tag?> GetAsync(TagId id);
    void DeleteAsync(Tag tag);
    Task<IEnumerable<Tag>> GetTags(IEnumerable<Guid> ids);
}
