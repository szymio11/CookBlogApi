using CookBlog.App.DTO;
using System.Net.Http.Json;
using CookBlog.App.Data;

namespace CookBlog.App.Services;
public class UserDataService : IUserDataService

{
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;
    private readonly CustomAuthenticationStateProvider _myAuthenticationStateProvider;

    public UserDataService(HttpClient httpClient, ITokenService tokenService,
        CustomAuthenticationStateProvider myAuthenticationStateProvider)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        _myAuthenticationStateProvider = myAuthenticationStateProvider;
    }

    public async Task<bool> AddUserAsync(CreateUserDto createUserDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"users", createUserDto);

        return response.IsSuccessStatusCode;
    }

    public async Task<JwtDto> LoginAsync(LoginUserDto loginUserDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"Users/sign-in", loginUserDto);
        var result = await response.Content.ReadFromJsonAsync<JwtDto>();
        await _tokenService.SetToken(result);
        _myAuthenticationStateProvider.StateChanged();

        return result;
    }

    public async Task LogoutAsync()
    {
        await _tokenService.RemoveToken();
        _myAuthenticationStateProvider.StateChanged();
    }
}