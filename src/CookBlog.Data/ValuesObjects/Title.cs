using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record Title
{
    public string Value { get; }

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 20 or < 3)
        {
            throw new InvalidTitleException(value);
        }

        Value = value;
    }

    public static implicit operator Title(string value) => new Title(value);
    public static implicit operator string(Title value) => value.Value;

    public override string ToString() => Value;
}
