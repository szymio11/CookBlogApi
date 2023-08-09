using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Repositories;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<Post?> GetAsync(PostId id);
    Task<bool> AnyAsync(PostId id);
    void DeleteAsync(Post post);
}
