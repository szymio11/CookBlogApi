using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Application.Exceptions;

public sealed class UserNameAlreadyInUseException : CustomException
{
    public string UserName { get; }

    public UserNameAlreadyInUseException(string userName) : base($"UserName: '{userName}' is already in use.")
    {
        UserName = userName;
    }
}
