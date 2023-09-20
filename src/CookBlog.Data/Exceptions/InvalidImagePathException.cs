namespace CookBlog.Api.Core.Exceptions;

public sealed class InvalidImagePathException : CustomException
{
    public string ImagePath { get; }

    public InvalidImagePathException(string imagePath) : base($"ImagePath:'{imagePath}' is invalid")
    {
        ImagePath = imagePath;
    }
}