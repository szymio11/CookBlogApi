using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Categories;

public partial class CategoryDetail
{
    [Parameter]
    public string CategoryId { get; set; }
    public CategoryDto CategoryDto { get; set; } = new CategoryDto();

    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CategoryDto = await CategoryDataService.GetCategoryAsync(Guid.Parse(CategoryId));
    }
}

