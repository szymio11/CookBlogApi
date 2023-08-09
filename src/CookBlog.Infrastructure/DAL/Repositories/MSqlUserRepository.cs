using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Repositories;

internal sealed class MSqlUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public MSqlUserRepository(MyCookBlogDbContext dbContext) 
        => _users = dbContext.Users;

    public async Task AddAsync(User user)
        => await _users.AddAsync(user);

    public Task<User?> GetByIdAsync(UserId id) 
        => _users.SingleOrDefaultAsync(x => x.Id == id);

    public Task<User?> GetByEmailAsync(Email email) 
        => _users.SingleOrDefaultAsync(u => u.Email == email);

    public Task<User?> GetByUserNameAsync(UserName userName) 
        => _users.SingleOrDefaultAsync(u => u.UserName == userName);
}
