using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryEdit
{
    [Parameter]
    public string CategoryId { get; set; }
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();

    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

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
        if (CategoryDto.Id == Guid.Empty)
        {
            var isAddedCategory = await CategoryDataService.AddCategoryAsync(CategoryDto);
            if (isAddedCategory)
            {
                StatusClass = "alert-success";
                Message = "New category added successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new category. Please try again.";
                Saved = false;
            }
        }
        else
        {
            await CategoryDataService.UpdateCategory(Guid.Parse(CategoryId), CategoryDto);
            StatusClass = "alert-success";
            Message = "Category updated successfully.";
            Saved = true;
        }
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteCategory()
    {
        await CategoryDataService.DeleteCategoryAsync(CategoryDto.Id);

        StatusClass = "alert-success";
        Message = "Deleted successfully";

        Saved = true;
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/categoryoverview");
    }
}
