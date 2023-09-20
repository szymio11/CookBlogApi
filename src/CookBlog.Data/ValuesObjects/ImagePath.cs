using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public class ImagePath
{
    public string Value { get; set; }

    public ImagePath(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidImagePathException(value);
        }

        Value = value;
    }

    public static implicit operator ImagePath(string value) => value is null ? null : new ImagePath(value);
    public static implicit operator string(ImagePath value) => value.Value;

    public override string ToString() => Value;
}
