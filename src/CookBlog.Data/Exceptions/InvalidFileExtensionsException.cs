using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Core.Exceptions;

public sealed class InvalidFileExtensionsException : CustomException
{
    public string File { get; }
    
    public InvalidFileExtensionsException(string file) : base($"File:'{file}' is invalid image")
    {
        File = file;
    }
}
