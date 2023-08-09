using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;

namespace CookBlog.Api.Application.Queries;

public class GetUsers : IQuery<IEnumerable<UserDto>>
{
}
