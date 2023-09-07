using CookBlog.App.DTO;
using System.Net.Http.Json;

namespace CookBlog.App.Services;

public sealed class PostDataService : IPostDataService
{
    private readonly HttpClient _httpClient;

    public PostDataService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<bool> AddPostAsync(CreatePostDto createPostDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"post", createPostDto);

        return response.IsSuccessStatusCode;
    }

    public async Task DeletePostAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"post/{id}");
    }

    public async Task<PostDto?> GetPostAsync(Guid id) 
        => await _httpClient.GetFromJsonAsync<PostDto?>($"post/{id}");

    public async Task<IEnumerable<PostDto>?> GetPostsAsync() 
        => await _httpClient.GetFromJsonAsync<IEnumerable<PostDto>?>("posts");

    public async Task UpdatePostAsync(Guid id, UpdatePostDto updatePostDto)
    {
        await _httpClient.PutAsJsonAsync($"post/{id}", updatePostDto);
    }

}
