using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Entities;

public class Category
{
    public CategoryId Id { get; private set; }
    public FullName FullName { get; private set; }
    public IEnumerable<Post> Posts => _posts;

    private readonly HashSet<Post> _posts = new HashSet<Post>();

    public Category()
    {
    }

    public Category(CategoryId categoryId, FullName fullName)
    {
        Id = categoryId;
        FullName = fullName;
    }

    public static Category Create(FullName fullName) => new Category(Guid.NewGuid(), fullName);
    public void Update(FullName fullName) => FullName = fullName;
}
