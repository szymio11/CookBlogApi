using Blazored.LocalStorage;
using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public class TokenService : ITokenService
{
    private const string Token = "accessToken";
    private readonly ILocalStorageService _localStorageService;

    public TokenService(ILocalStorageService localStorageService)
        => _localStorageService = localStorageService;

    public async Task<JwtDto> GetToken()
        => await _localStorageService.GetItemAsync<JwtDto>(Token);

    public async Task RemoveToken()
        => await _localStorageService.RemoveItemAsync(Token);

    public async Task SetToken(JwtDto accessToken)
        => await _localStorageService.SetItemAsync(Token, accessToken);
}
