using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Core.Exceptions;

public sealed class InvalidFileException : CustomException
{
    public string File { get; }

    public InvalidFileException(string file) : base($"File:'{file}' is invalid")
    {
        File = file;
    }
}
