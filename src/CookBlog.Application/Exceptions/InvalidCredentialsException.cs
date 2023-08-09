using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Application.Exceptions;

public class InvalidCredentialsException : CustomException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {   
    }
}
