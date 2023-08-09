using CookBlog.Api.Application.Abstractions;

namespace CookBlog.Api.Application.Commands;

public record SignIn(string Email, string Password) : ICommand;
