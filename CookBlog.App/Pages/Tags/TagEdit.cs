using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Tags;

public partial class TagEdit
{
    [Inject]
    public ITagDataService TagDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string TagId { get; set; }
    public TagDto TagDto { get; set; } = new TagDto();
    public UpdateTagDto UpdateTagDto { get; set; } = new UpdateTagDto();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected override async Task OnInitializedAsync()
    {
        Saved = false;

        if (Guid.TryParse(TagId, out var tagId))
        {
            TagDto = await TagDataService.GetTagAsync(tagId);
        }
    }

    protected async Task HandleValidSubmit()
    {
        var updateTagDto = new UpdateTagDto { Description = TagDto.Description };

        await TagDataService.UpdateTagAsync(Guid.Parse(TagId), updateTagDto);
        StatusClass = "alert-success";
        Message = "Tag updated successfully.";
        Saved = true;
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/tagoverview");
    }
}
