using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record UpdateComment(Guid CommentId, string FullName, string Description) : ICommand;
