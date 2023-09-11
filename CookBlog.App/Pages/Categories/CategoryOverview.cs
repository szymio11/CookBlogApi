using CookBlog.App.Components;
using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryOverview
{
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }
    [Inject]
    public IDialogService DialogService { get; set; }

    protected AddCategoryDialog AddCategoryDialog { get; set; }
    public IEnumerable<CategoryDto> CategoryDtos { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
    }

    private async Task OpenDialog()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        var dialog = DialogService.Show<AddCategoryDialog>("Dodanie Kategorii:", options);

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
            StateHasChanged();
        }
    }

    private async Task DeleteCategoryAsync(Guid id)
    {
        var parameters = new DialogParameters();
        parameters.Add($"CategoryId", id);
        var dialog = await DialogService.ShowAsync<CategoryDelete>("Delete Category", parameters);

        var result = await dialog.Result;
        if(!result.Cancelled)
        {
            CategoryDtos = CategoryDtos.Where(x => x.Id != id).ToList();
            StateHasChanged();
        }    
    }
}
