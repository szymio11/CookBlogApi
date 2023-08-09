using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Entities;

public class Tag
{
    public TagId Id { get; set; }
    public Description Description { get; set; }
    public IEnumerable<Post> Posts => _posts;

    private readonly HashSet<Post> _posts = new HashSet<Post>();

    public Tag()
    {
    }

    private Tag(TagId id, Description description)
    {
        Id = id;
        Description = description;
    }

    public static Tag Create(Description description) => new Tag(Guid.NewGuid(), description);
    public void Update(Description description) => Description = description;
}
