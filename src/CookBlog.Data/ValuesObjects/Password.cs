using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is < 6)
            throw new InvalidPasswordException();

        Value = value;
    }

    public static implicit operator Password(string value) => new(value);
    public static implicit operator string(Password value) => value?.Value;

    public override string ToString() => Value;
}
