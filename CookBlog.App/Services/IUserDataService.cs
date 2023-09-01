using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface IUserDataService
{
    Task<bool> AddUserAsync(CreateUserDto createUserDto);
    Task<JwtDto> LoginAsync(LoginUserDto loginUserDto);
    Task LogoutAsync();
}
