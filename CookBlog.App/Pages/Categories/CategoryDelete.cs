using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryDelete
{
    [CascadingParameter] 
    MudDialogInstance MudDialog { get; set; }

    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();

    [Parameter]
    public Guid CategoryId { get; set; }

    private async Task ConfirmDeleteAsync()
    {
        await CategoryDataService.DeleteCategoryAsync(CategoryId);
        MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel()
    {
        MudDialog.Cancel();
        StateHasChanged();
    }
}
