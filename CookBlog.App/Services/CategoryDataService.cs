using CookBlog.App.DTO;
using System.Text;
using System.Text.Json;

namespace CookBlog.App.Services;

public sealed class CategoryDataService : ICategoryDataService
{
    private readonly HttpClient _httpClient;

    public CategoryDataService(HttpClient httpClient) 
        => _httpClient = httpClient;

    public async Task<bool> AddCategoryAsync(CreateCategoryDto createCategorytDto)
    {
        var categoryJson =
            new StringContent(JsonSerializer.Serialize(createCategorytDto), Encoding.UTF8, $"application/json");

        var response = await _httpClient.PostAsync($"category", categoryJson);

        return response.IsSuccessStatusCode;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"category/{id}");
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        return await JsonSerializer.DeserializeAsync<IEnumerable<CategoryDto>>
              (await _httpClient.GetStreamAsync($"categories"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<CategoryDto?> GetCategoryAsync(Guid id)
    {
        return await JsonSerializer.DeserializeAsync<CategoryDto>
             (await _httpClient.GetStreamAsync($"category/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto)
    {
        var categoryJson = new StringContent(JsonSerializer.Serialize(updateCategoryDto), Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"category/{id}", categoryJson);
    }
}
