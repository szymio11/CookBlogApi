using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record CreatePost(string Title, string Description,
    Guid CategoryId, Guid? UserId, ICollection<Guid> Tags) : ICommand;

