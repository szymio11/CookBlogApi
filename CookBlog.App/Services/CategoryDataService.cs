using CookBlog.App.DTO;
using System.Net.Http.Json;

namespace CookBlog.App.Services;

public sealed class CategoryDataService : ICategoryDataService
{
    private readonly HttpClient _httpClient;

    public CategoryDataService(HttpClient httpClient) 
        => _httpClient = httpClient;

    public async Task<bool> AddCategoryAsync(CreateCategoryDto createCategorytDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"category", createCategorytDto);

        return response.IsSuccessStatusCode;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"category/{id}");
    }

    public async Task<IEnumerable<CategoryDto>?> GetCategoriesAsync() 
        => await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>?>("categories");

    public async Task<CategoryDto?> GetCategoryAsync(Guid id) 
        => await _httpClient.GetFromJsonAsync<CategoryDto>($"category/{id}");

    public async Task UpdateCategory(Guid id, UpdateCategoryDto updateCategoryDto)
    {
        await _httpClient.PutAsJsonAsync($"category/{id}", updateCategoryDto);
    }
}
