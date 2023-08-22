using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Pages.Tags;

public partial class TagDelete
{
    [CascadingParameter] 
    MudDialogInstance MudDialog { get; set; }

    [Inject]
    public ITagDataService TagDataService { get; set; }
    public TagDto TagDto { get; set; }

    [Parameter]
    public Guid TagId { get; set; }

    private async Task ConfirmDeleteAsync()
    {
        await TagDataService.DeleteTagAsync(TagId);
        MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel()
    {
        MudDialog.Cancel();
        StateHasChanged();
    }
}
