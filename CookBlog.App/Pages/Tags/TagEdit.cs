using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Tags;

public partial class TagEdit
{
    [Parameter]
    public string TagId { get; set; }
    public TagDto TagDto { get; set; } = new TagDto();

    [Inject]
    public ITagDataService TagDataService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

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
        Saved = false;
        if (TagDto.Id == Guid.Empty)
        {
            var isAddedTag = await TagDataService.AddTagAsync(TagDto);
            if (isAddedTag)
            {
                StatusClass = "alert-success";
                Message = "New tag added successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Something went wrong adding the new tag. Please try again.";
                Saved = false;
            }
        }
        else
        {
            await TagDataService.UpdateTagAsync(Guid.Parse(TagId), TagDto);
            StatusClass = "alert-success";
            Message = "Tag updated successfully.";
            Saved = true;
        }
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteTag()
    {
        await TagDataService.DeleteTagAsync(TagDto.Id);

        StatusClass = "alert-success";
        Message = "Deleted successfully";

        Saved = true;
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/tagoverview");
    }
}
