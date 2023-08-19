using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Posts;

public partial class PostDetail
{
    [Parameter]
    public string PostId { get; set; }
    public PostDto PostDto { get; set; } = new PostDto();

    [Inject]
    public IPostDataService PostDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PostDto = await PostDataService.GetPostAsync(Guid.Parse(PostId));
    }
}
