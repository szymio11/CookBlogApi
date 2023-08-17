using CookBlog.App.DTO;
using System.Text;
using System.Text.Json;

namespace CookBlog.App.Services;

public class TagDataService : ITagDataService
{
    private readonly HttpClient _httpClient;

    public TagDataService(HttpClient httpClient) 
        => _httpClient = httpClient;

    public async Task<bool> AddTagAsync(TagDto tagDto)
    {
        var tagJson =
            new StringContent(JsonSerializer.Serialize(tagDto), Encoding.UTF8, $"application/json");

        var response = await _httpClient.PostAsync($"tag", tagJson);

        return response.IsSuccessStatusCode;
    }

    public async Task DeleteTagAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"tag/{id}");
    }

    public async Task<TagDto?> GetTagAsync(Guid id)
    {
        return await JsonSerializer.DeserializeAsync<TagDto>
             (await _httpClient.GetStreamAsync($"tag/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<IEnumerable<TagDto>> GetTagsAsync()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<TagDto>>
              (await _httpClient.GetStreamAsync($"tags"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task UpdateTagAsync(Guid id, TagDto tagDto)
    {
        var tagJson = new StringContent(JsonSerializer.Serialize(tagDto), Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"tag/{id}", tagJson);
    }
}