using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public sealed record DeletePost(Guid PostId) : ICommand; 
