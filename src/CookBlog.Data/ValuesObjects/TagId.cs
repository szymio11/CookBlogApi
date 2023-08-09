using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record TagId
{
    public Guid Value { get; }

    public TagId(Guid value)
    {
        if(value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(TagId date) => date.Value;
    public static implicit operator TagId(Guid value) => new TagId(value);
}
