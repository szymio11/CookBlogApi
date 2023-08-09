
using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public record SignUp(Guid UserId, string Email, string UserName, string Password, string FullName, string Role) : ICommand;
