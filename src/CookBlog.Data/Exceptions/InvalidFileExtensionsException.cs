using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Core.Exceptions;

public sealed class InvalidFileExtensionsException : CustomException
{
    public string Extension { get; }

    public InvalidFileExtensionsException(string extension) : base($"Extension:'{extension}' is invalid")
    {
        Extension = extension;
    }
}
