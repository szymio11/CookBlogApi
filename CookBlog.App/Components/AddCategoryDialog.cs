using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Components;

public partial class AddCategoryDialog
{
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    [Parameter]
    public EventCallback<bool> CloseEventCallBack { get; set; }

    [CascadingParameter]
    MudDialogInstance MudDialog { get; set; }
    public CreateCategoryDto CreateCategoryDto { get; set; } = new CreateCategoryDto();
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();


    protected async Task HandleValidSubmit()
    {
        var createCategoryDto = new CreateCategoryDto
        {
            FullName = CategoryDto.FullName
        };
        await CategoryDataService.AddCategoryAsync(createCategoryDto);

        await CloseEventCallBack.InvokeAsync(true);
        StateHasChanged();
        MudDialog.Close(DialogResult.Ok(true));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
        StateHasChanged();
    }
}
