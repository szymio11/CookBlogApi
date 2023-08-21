using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryCreate
{
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string CategoryId { get; set; }
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();
    public CreateCategoryDto CreateCategoryDto { get; set; } = new CreateCategoryDto();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var createCategoryDto = new CreateCategoryDto { FullName = CategoryDto.FullName };

        var isAddCategory = await CategoryDataService.AddCategoryAsync(createCategoryDto);
        if (isAddCategory)
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
