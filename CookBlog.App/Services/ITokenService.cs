using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface ITokenService
{
    Task<JwtDto> GetToken();
    Task RemoveToken();
    Task SetToken(JwtDto accessToken);
}
