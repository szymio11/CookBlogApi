namespace CookBlog.Api.Core.Exceptions;

public sealed class InvalidTitleException : CustomException
{
    public string Title { get; }

    public InvalidTitleException(string title) : base($"Title: '{title}' is invalid.")
    {
        Title = title;
    }
}
