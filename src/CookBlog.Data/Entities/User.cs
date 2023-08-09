using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Core.Entities;

public class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public UserName UserName { get; private set; }
    public Password Password { get; private set; }
    public FullName FullName { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IEnumerable<Post> Posts => _posts;

    private readonly HashSet<Post> _posts = new HashSet<Post>();

    public User()
    {
    }

    public User(UserId id, Email email, UserName userName, Password password, FullName fullName, Role role,
        DateTime createdAt)
    {
        Id = id;
        Email = email;
        UserName = userName;
        Password = password;
        FullName = fullName;
        Role = role;
        CreatedAt = createdAt;
    }
}
