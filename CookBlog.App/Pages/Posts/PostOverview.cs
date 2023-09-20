using CookBlog.App.Components;
using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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
        var dialog = DialogService.Show<AddPostDialog>("", options);

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            PostDtos = (await PostDataService.GetPostsAsync()).ToList();
            StateHasChanged();
        }
    }

    private async Task DeletePostAsync(Guid id)
    {
        var parameters = new DialogParameters();
        parameters.Add("PostId", id);
        var dialog = await DialogService.ShowAsync<PostDelete>($"Delete Post", parameters);

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            PostDtos = PostDtos.Where(x => x.Id != id).ToList();
            StateHasChanged();
        }
    }
}
