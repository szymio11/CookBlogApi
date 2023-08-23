using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Pages.Posts;

public partial class PostDelete
{
    [CascadingParameter]
    MudDialogInstance MudDialog { get; set; }

    [Inject]
    public IPostDataService PostDataService { get; set; }

    public PostDto PostDto { get; set; } = new PostDto();

    [Parameter]
    public Guid PostId { get; set; }

    private async Task ConfirmDeleteAsync()
    {
        await PostDataService.DeletePostAsync(PostId);
        MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel()
    {
        MudDialog.Cancel();
        StateHasChanged();
    }
}
