using CookBlog.App.Components;
using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Tags;

public partial class TagOverview
{
    [Inject]
    public ITagDataService TagDataService { get; set; }

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
}
 