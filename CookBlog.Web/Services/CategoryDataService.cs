using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using System.Text.Json;

namespace CookBlog.Web.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly HttpClient _httpClient;

        public CategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(CategoryId id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Category>>
                  (await _httpClient.GetStreamAsync($"api/categories"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category?> GetAsync(CategoryId id)
        {
            return await JsonSerializer.DeserializeAsync<Category>
                 (await _httpClient.GetStreamAsync($"api/category/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
