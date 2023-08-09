using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Application.Exceptions;

public class NotFoundTagException : CustomException
{
    public NotFoundTagException() : base($"Tag was not found.")
    {
    }            
}
