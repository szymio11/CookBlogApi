using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Users;

public partial class UserCreateAccount
{
    [Inject]
    public IUserDataService UserDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string UserId { get; set; }
    public UserDto UserDto { get; set; } = new UserDto();
    public CreateUserDto CreateUserDto { get; set; } = new CreateUserDto();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var createUserDto = new CreateUserDto { Email = UserDto.Email,
            Password = UserDto.Password, UserName = UserDto.UserName, FullName = UserDto.FullName, Role = UserDto.Role };

        var isAddUser = await UserDataService.AddUserAsync(createUserDto);
        if (isAddUser)
        {
            StatusClass = "alert-success";
            Message = "New user added successfully.";
            Saved = true;
        }
        else
        {
            StatusClass = "alert-danger";
            Message = "Something went wrong adding the new user. Please try again.";
            Saved = false;
        }
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/useroverview");
    }
}
