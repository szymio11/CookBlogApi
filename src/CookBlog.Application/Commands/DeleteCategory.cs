using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record DeleteCategory(Guid CategoryId) : ICommand;
