using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface IUserDataService
{
    Task<bool> AddUserAsync(CreateUserDto createUserDto);
}
