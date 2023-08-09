using CookBlog.Api.Core.Exceptions;

namespace CookBlog.Api.Core.ValuesObjects;

public sealed record CommentId
{
    public Guid Value { get; }

    public CommentId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(CommentId date) => date.Value;
    public static implicit operator CommentId(Guid value) => new CommentId(value);
}
