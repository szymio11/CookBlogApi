using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record DeleteComment(Guid CommentId) : ICommand;