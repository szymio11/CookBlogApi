namespace CookBlog.Api.Core.Exceptions;

public sealed class InvalidDescriptionException : CustomException
{
    public string Description { get; }

    public InvalidDescriptionException(string description) : base($"Description:'{description}' is invalid")
    {
        Description = description;
    }
}
