using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using CookBlog.Api.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetUserHandler(MyCookBlogDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var userId = new UserId(query.UserId);
        var user = await _dbContext.Users
            .AsNoTracking()
            .Select(Extensions.AsUserDto())
            .SingleOrDefaultAsync(u => u.Id == userId.Value);

        return user;
    }
}