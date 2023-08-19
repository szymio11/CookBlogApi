using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Posts;

public partial class PostOverview
{
    public IEnumerable<PostDto> PostDtos { get; set; }

    [Inject]
    public IPostDataService PostDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PostDtos = (await PostDataService.GetPostsAsync()).ToList();
    }
}
