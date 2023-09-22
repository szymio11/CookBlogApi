using CookBlog.App.DTO;
using Microsoft.AspNetCore.Components.Forms;

namespace CookBlog.App.Services;

public interface IPostDataService
{
    Task<IEnumerable<PostDto>?> GetPostsAsync();
    Task<PostDto?> GetPostAsync(Guid id);
    Task<bool> AddPostAsync(CreatePostDto createPostDto);
    Task UpdatePostAsync(Guid id, UpdatePostDto updatePostDto);
    Task UpdateImagePostAsync(Guid id, IBrowserFile file);
    Task DeletePostAsync(Guid id);
    Task<string?> GetImage(Guid id);
}
