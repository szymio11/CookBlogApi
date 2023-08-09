using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;

namespace CookBlog.Api.Application.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; set; }
}
