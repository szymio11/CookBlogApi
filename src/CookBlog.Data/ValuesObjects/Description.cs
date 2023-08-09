using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record Description
{
    public string Value { get; }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 3)
        {
            throw new InvalidDescriptionException(value);
        }

        Value = value;
    }

    public static implicit operator Description(string value) => value is null ? null : new Description(value);
    public static implicit operator string(Description value) => value?.Value;

    public override string ToString() => Value;
}

