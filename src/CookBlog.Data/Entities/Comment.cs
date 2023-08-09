using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Entities;

public class Comment
{
    public CommentId Id { get; }
    public FullName FullName { get; private set; }
    public Description Description { get; private set; }
    public PostId PostId { get; private set; }
    public Post Post { get; private set; }

    public Comment()
    {
    }

    private Comment(CommentId id, FullName fullName, Description description, PostId postId)
    {
        Id = id;
        FullName = fullName;
        Description = description;
        PostId = postId;
    }

    public static Comment Create(FullName fullName, Description description, PostId postId) 
        => new Comment(Guid.NewGuid(), fullName, description, postId);

    public void Update(FullName fullName, Description description)
    {
        FullName = fullName;
        Description = description;
    }
}
