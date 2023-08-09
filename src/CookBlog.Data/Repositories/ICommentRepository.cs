using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment);
    void DeleteAsync(Comment comment);
    Task<Comment?> GetAsync(CommentId id);
}
