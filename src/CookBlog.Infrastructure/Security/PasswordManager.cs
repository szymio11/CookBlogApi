using CookBlog.Api.Application.Security;
using CookBlog.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CookBlog.Api.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher) => _passwordHasher = passwordHasher;

    public string Secure(string password) => _passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string securedPassword)
        => _passwordHasher.VerifyHashedPassword(default, securedPassword, password) ==
           PasswordVerificationResult.Success;
}
