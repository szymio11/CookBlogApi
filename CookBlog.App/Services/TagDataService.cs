using CookBlog.App.DTO;
using System.Net.Http.Json;

namespace CookBlog.App.Services;

public class TagDataService : ITagDataService
{
    private readonly HttpClient _httpClient;

    public TagDataService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<bool> AddTagAsync(CreateTagDto createTagDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"tag", createTagDto);

        return response.IsSuccessStatusCode;
    }

    public async Task DeleteTagAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"tag/{id}");
    }

    public async Task<TagDto?> GetTagAsync(Guid id)
        => await _httpClient.GetFromJsonAsync<TagDto?>($"tag/{id}");

    public async Task<IEnumerable<TagDto>?> GetTagsAsync() 
        => await _httpClient.GetFromJsonAsync<IEnumerable<TagDto>?>($"tags");

    public async Task UpdateTagAsync(Guid id, UpdateTagDto updateTagDto)
    {
        await _httpClient.PutAsJsonAsync($"tag/{id}", updateTagDto);
    }
}