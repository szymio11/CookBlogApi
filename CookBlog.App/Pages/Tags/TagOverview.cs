using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Tags;

public partial class TagOverview
{
    public IEnumerable<TagDto> TagDtos { get; set; }

    [Inject]
    public ITagDataService TagDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        TagDtos = (await TagDataService.GetTagsAsync()).ToList();
    }
}
 