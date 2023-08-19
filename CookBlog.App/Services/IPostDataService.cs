using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface IPostDataService
{
    Task<IEnumerable<PostDto>> GetPostsAsync();
    Task<PostDto?> GetPostAsync(Guid id);
    Task<bool> AddPostAsync(CreatePostDto createPostDto);
    Task UpdatePostAsync(Guid id, UpdatePostDto updatePostDto);
    Task DeletePostAsync(Guid id);
}
