using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface ICommentDataService
{
    Task AddCommentAsync(CreateCommentDto createCommentDto);
}
