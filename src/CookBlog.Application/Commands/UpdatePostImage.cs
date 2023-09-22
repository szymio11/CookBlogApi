using CookBlog.Api.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace CookBlog.Application.Commands;

public sealed record UpdatePostImage(Guid PostId, IFormFile FormFile) : ICommand;
