using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryEdit
{
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string CategoryId { get; set; }
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();
    public UpdateCategoryDto UpdateCategoryDto { get; set; } = new UpdateCategoryDto();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected override async Task OnInitializedAsync()
    {
        Saved = false;

        if (Guid.TryParse(CategoryId, out var categoryId))
        {
            CategoryDto = await CategoryDataService.GetCategoryAsync(categoryId);
        }
    }

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var updateCategryDto = new UpdateCategoryDto { FullName = CategoryDto.FullName };

        await CategoryDataService.UpdateCategory(Guid.Parse(CategoryId), updateCategryDto);
        StatusClass = "alert-success";
        Message = "Category updated successfully.";
        Saved = true;
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/categoryoverview");
    }
}
