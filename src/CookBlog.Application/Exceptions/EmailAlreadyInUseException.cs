using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Application.Exceptions;

public sealed class EmailAlreadyInUseException : CustomException
{
    public EmailAlreadyInUseException(string email) : base($"Email: '{email}' is already in use.")
    {
        Email = email;
    }

    public string Email { get; }
}