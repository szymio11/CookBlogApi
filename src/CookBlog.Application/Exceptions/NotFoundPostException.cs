using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Application.Exceptions;

public class NotFoundPostException : CustomException
{
    public NotFoundPostException(Guid id) : base($"Post with ID: {id} was not found.") 
        => Id = id;

    public Guid Id { get; }
}
