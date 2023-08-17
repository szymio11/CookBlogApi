using CookBlog.Api.Core.Entities;
using CookBlog.Web.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.Web.Pages
{
    public partial class CategoryDetail
    {
        [Parameter]
        public string CategoryId { get; set; }

        public Category Category { get; set; } = new Category();

        public IEnumerable<Category> Categories { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Category = await CategoryDataService.GetAsync(Guid.Parse(CategoryId));
        }
    }
}
