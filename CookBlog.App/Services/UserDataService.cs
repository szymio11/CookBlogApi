using CookBlog.App.DTO;
using System.Text.Json;
using System.Text;

namespace CookBlog.App.Services;

public class UserDataService : IUserDataService
{
    private readonly HttpClient _httpClient;

    public UserDataService(HttpClient httpClient) 
        => _httpClient = httpClient;

    public async Task<bool> AddUserAsync(CreateUserDto createUserDto)
    {
        var userJson =
            new StringContent(JsonSerializer.Serialize(createUserDto), Encoding.UTF8, $"application/json");

        var response = await _httpClient.PostAsync($"users", userJson);

        return response.IsSuccessStatusCode;
    }
}
