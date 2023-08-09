using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Entities;

public class Post
{
    public PostId Id { get; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Category Category { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }
    public IEnumerable<Tag> Tags => _tags;
    public IEnumerable<Comment> Comments => _comments;

    private readonly HashSet<Tag> _tags = new HashSet<Tag>();
    private readonly HashSet<Comment> _comments = new HashSet<Comment>();

    public Post()
    {
    }

    private Post(PostId id, Title title, Description description, CategoryId categoryId,
        UserId userId, HashSet<Tag> tags)
    {
        Id = id;
        Title = title;
        Description = description;
        CategoryId = categoryId;
        UserId = userId;
        _tags = tags;
    }

    public static Post Create(Title title, Description description,
        CategoryId categoryId, UserId userId, HashSet<Tag> tags)
        => new Post(Guid.NewGuid(), title, description, categoryId, userId, tags);

    public void Update(Title title, Description description, CategoryId categoryId, HashSet<Tag> tags)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;

        var tagsToRemoved = _tags.Where(oldTag => !tags.Any(newTag => newTag.Id == oldTag.Id)).ToList();
        foreach (var tagToRemoved in tagsToRemoved)
        {
            _tags.Remove(tagToRemoved);
        }

        var newTags = tags.Where(newTag => !_tags.Any(oldTag => oldTag.Id == newTag.Id)).ToList();
        foreach (var newTag in newTags)
        {
            _tags.Add(newTag);
        }
    }
}
