using CookBlog.App.Components;
using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Pages.Tags;

public partial class TagOverview
{
    [Inject]
    public ITagDataService TagDataService { get; set; }
    [Inject]
    public IDialogService DialogService { get; set; }

    public AddTagDialog AddTagDialog { get; set; }
    public IEnumerable<TagDto> TagDtos { get; set; }

    protected override async Task OnInitializedAsync()
    {
        TagDtos = (await TagDataService.GetTagsAsync()).ToList();
    }

    protected void QuickAddTag()
    {
        AddTagDialog.Show();
    }

    public async void AddTagDialog_OnDialogClose()
    {
        TagDtos = (await TagDataService.GetTagsAsync()).ToList();
        StateHasChanged();
    }

    private async Task DeleteTagAsync(Guid id)
    {
        var parameters = new DialogParameters();
        parameters.Add($"TagId", id);
        var dialog = await DialogService.ShowAsync<TagDelete>($"Delete Tag", parameters);

        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            TagDtos = TagDtos.Where(x => x.Id != id).ToList();
            StateHasChanged();
        }
    }
}
 