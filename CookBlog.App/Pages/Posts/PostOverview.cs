using CookBlog.App.Components;
using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;

namespace CookBlog.App.Pages.Posts;

public partial class PostOverview
{
    [Inject]
    public IPostDataService PostDataService { get; set; }
    [Inject]
    public IDialogService DialogService { get; set; }

    public AddPostDialog AddPostDialog { get; set; }
    public IEnumerable<PostDto> PostDtos { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PostDtos = (await PostDataService.GetPostsAsync()).ToList();
    }

    private async Task OpenDialog()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        var dialog = DialogService.Show<AddPostDialog>("Simple Dialog", options);
        var result = await dialog.Result;
        var isSucces = result.Data.As<bool>();
        if (isSucces)
        {
            PostDtos = (await PostDataService.GetPostsAsync()).ToList();
            StateHasChanged();
        }
    }
}
