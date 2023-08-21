using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Tags;

public partial class TagCreate
{
    [Inject]
    public ITagDataService TagDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string TagId { get; set; }
    public TagDto TagDto { get; set; } = new TagDto();

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var createTagDto = new CreateTagDto { Description = TagDto.Description };

        var isAddTag = await TagDataService.AddTagAsync(createTagDto);
        if (isAddTag)
        {
            StatusClass = "alert-success";
            Message = "New post added successfully.";
            Saved = true;
        }
        else
        {
            StatusClass = "alert-danger";
            Message = "Something went wrong adding the new post. Please try again.";
            Saved = false;
        }
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
