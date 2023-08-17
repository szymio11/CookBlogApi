using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Components;

public partial class AddCategoryDialog
{
    public CategoryDto CategoryDto { get; set; } = new CategoryDto { FullName = ""};

    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    public bool ShowDialog { get; set; }

    [Parameter]
    public EventCallback<bool> CloseEventCallBack { get; set; }

    public void Show()
    {
        ResetDialog();
        ShowDialog = true;
        StateHasChanged();
    }

    public void Close()
    {
        ShowDialog = false;
        StateHasChanged();
    }

    private void ResetDialog()
    {
        CategoryDto = new CategoryDto { FullName = "" };
    }

    protected async Task HandleValidSubmit()
    {
        await CategoryDataService.AddCategoryAsync(CategoryDto);
        ShowDialog = false;

        await CloseEventCallBack.InvokeAsync(true);
        StateHasChanged();
    }
}
