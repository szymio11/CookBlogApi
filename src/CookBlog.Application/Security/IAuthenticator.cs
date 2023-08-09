using CookBlog.Api.Application.DTO;

namespace CookBlog.Api.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}
