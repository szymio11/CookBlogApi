using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly MyCookBlogDbContext _dbContext;

    public GetUsersHandler(MyCookBlogDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query) 
        => await _dbContext.Users
            .AsNoTracking()
            .Select(Extensions.AsUserDto())
            .ToListAsync();
}
