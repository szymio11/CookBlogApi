using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record UpdateTag(Guid TagId, string Description) : ICommand;

