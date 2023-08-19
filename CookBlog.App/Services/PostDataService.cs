using CookBlog.App.DTO;
using System.Text;
using System.Text.Json;

namespace CookBlog.App.Services;

public sealed class PostDataService : IPostDataService
{
    private readonly HttpClient _httpClient;

    public PostDataService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<bool> AddPostAsync(CreatePostDto createPostDto)
    {
        var postJson =
            new StringContent(JsonSerializer.Serialize(createPostDto), Encoding.UTF8, $"application/json");

        var response = await _httpClient.PostAsync($"post", postJson);

        return response.IsSuccessStatusCode;
    }

    public async Task DeletePostAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"post/{id}");
    }

    public async Task<PostDto?> GetPostAsync(Guid id)
    {
        return await JsonSerializer.DeserializeAsync<PostDto>
            (await _httpClient.GetStreamAsync($"post/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<IEnumerable<PostDto>> GetPostsAsync()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<PostDto>>
            (await _httpClient.GetStreamAsync($"posts"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task UpdatePostAsync(Guid id, UpdatePostDto updatePostDto)
    {
        var serializer = JsonSerializer.Serialize(updatePostDto);

        var postJson = new StringContent(serializer, Encoding.UTF8, "application/json");

        var result = await _httpClient.PutAsync($"post/{id}", postJson);

        var r = await result.Content.ReadAsStringAsync();
    }

}
