using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record CategoryId
{
    public Guid Value { get; }

    public CategoryId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(CategoryId date) => date.Value;
    public static implicit operator CategoryId(Guid value) => new CategoryId(value);
}
