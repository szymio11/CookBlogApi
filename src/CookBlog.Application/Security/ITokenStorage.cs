using CookBlog.Api.Application.DTO;

namespace CookBlog.Api.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}
