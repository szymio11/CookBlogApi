using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Posts;

public partial class PostEdit
{
    [Inject]
    public IPostDataService PostDataService { get; set; }
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }
    [Inject]
    public ITagDataService TagDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PostId { get; set; }
    public PostDto PostDto { get; set; } = new PostDto();
    public List<CategoryDto> CategoryDtos { get; set; } = new List<CategoryDto>();
    public IEnumerable<TagDto> TagDtos { get; set; } = new List<TagDto>();
    public IEnumerable<TagDto> SelectedTagDtos { get; set; } = new List<TagDto>();

    protected string CategoryId = string.Empty;
    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    protected bool Saved;

    protected override async Task OnInitializedAsync()
    {
        Saved = false;
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
        TagDtos = (await TagDataService.GetTagsAsync()).ToList();

        if (Guid.TryParse(PostId, out var postId))
        {
            PostDto = await PostDataService.GetPostAsync(postId);
        }
       
        CategoryId = PostDto.Category.Id.ToString();
        SelectedTagDtos = PostDto.Tags;
    }
    
    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var updatePostDto = new UpdatePostDto
        {
            Title = PostDto.Title,
            Description = PostDto.Description,
            CategoryId = Guid.Parse(CategoryId),
            Tags = SelectedTagDtos.Select(tagDto => tagDto.Id)
        };

        await PostDataService.UpdatePostAsync(Guid.Parse(PostId), updatePostDto);
        StatusClass = "alert-success";
        Message = "Post updated successfully.";
        Saved = true;
    }

    protected void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeletePost()
    {
        await PostDataService.DeletePostAsync(PostDto.Id);

        StatusClass = "alert-success";
        Message = "Deleted successfully";

        Saved = true;
    }

    protected void NavigateToOverview()
    {
        NavigationManager.NavigateTo("/postoverview");
    }
}
