using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages;

public partial class CategoryOverview
{
    public IEnumerable<CategoryDto> CategoryDtos { get; set; }

    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
    }
}
