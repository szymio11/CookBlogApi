using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Application.Security;
using CookBlog.Api.Core.Abstractions;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;

    public SignUpHandler(IUserRepository userRepository,
        IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
    }

    public async Task HandleAsync(SignUp command)
    {
        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);
        var userName = new UserName(command.UserName);
        var password = new Password(command.Password);
        var fullName = new FullName(command.FullName);
        var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);

        if (await _userRepository.GetByEmailAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        if (await _userRepository.GetByUserNameAsync(userName) is not null)
            throw new UserNameAlreadyInUseException(userName);

        var securedPassword = _passwordManager.Secure(password);
        var user = new User(userId, email, userName, securedPassword, fullName, role, _clock.Current());
        await _userRepository.AddAsync(user);
    }
}