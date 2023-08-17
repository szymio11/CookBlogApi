using CookBlog.App.Components;
using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryOverview
{
    public IEnumerable<CategoryDto> CategoryDtos { get; set; }

    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    protected AddCategoryDialog AddCategoryDialog { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
    }

    protected void QuickAddCategory()
    {
        AddCategoryDialog.Show();
    }

    public async void AddCategoryDialog_OnDialogClose()
    {
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
        StateHasChanged();
    }
}
