using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record UpdatePost(Guid PostId, string Title,
    string Description, Guid CategoryId, ICollection<Guid> Tags) : ICommand;


