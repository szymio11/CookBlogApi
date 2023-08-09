using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public record UpdateCategory(Guid CategoryId, string FullName) : ICommand;
