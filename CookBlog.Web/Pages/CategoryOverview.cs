using CookBlog.Api.Core.Entities;
using CookBlog.Web.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.Web.Pages
{
    public partial class CategoryOverview
    {
        public IEnumerable<Category> Categories { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Categories = (await CategoryDataService.GetAllAsync()).ToList();
        }
    }
}
