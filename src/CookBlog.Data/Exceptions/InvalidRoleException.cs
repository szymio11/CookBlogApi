namespace CookBlog.Api.Core.Exceptions;

public sealed class InvalidRoleException : CustomException
{
    public string Role { get; }

    public InvalidRoleException(string role) : base($"Invalid Role")
    {
        Role = role;
    }
}
