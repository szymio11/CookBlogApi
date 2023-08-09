using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record PostId
{
    public Guid Value { get; }

    public PostId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static PostId Create() => new PostId(Guid.NewGuid());

    public static implicit operator Guid(PostId date) => date.Value;
    public static implicit operator PostId(Guid value) => new PostId(value);

    public override string ToString() => Value.ToString();
}
