using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Tags;

public partial class TagDetail
{
    [Parameter]
    public string TagId { get; set; }
    public TagDto TagDto { get; set; } = new TagDto();

    [Inject]
    public ITagDataService TagDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        TagDto = await TagDataService.GetTagAsync(Guid.Parse(TagId));
    }
}
