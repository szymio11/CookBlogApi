using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Application.Exceptions;

public class NotFoundCommentException : CustomException
{
    public Guid Id { get; }

    public NotFoundCommentException(Guid id) : base($"Comment with ID: {id} was not found.") 
        => Id = id;
}
