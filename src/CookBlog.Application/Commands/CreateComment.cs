using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record CreateComment(string FullName, string Description, Guid PostId) : ICommand; 
