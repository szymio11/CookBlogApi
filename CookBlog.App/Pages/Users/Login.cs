using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Users;

public partial class Login
{
    [Inject]
    public IUserDataService UserDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }


    [Parameter]
    public string UserId { get; set; }
    public LoginUserDto LoginUserDto { get; set; } = new LoginUserDto();

    private async Task HandleLogin()
    {
        await UserDataService.LoginAsync(LoginUserDto);

        NavigationManager.NavigateTo("");
    }
}

  