using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByEmailAsync(Email email);
    Task<User?> GetByUserNameAsync(UserName userName);
    Task AddAsync(User user);
}
