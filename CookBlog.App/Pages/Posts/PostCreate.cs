using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Pages.Posts;

public partial class PostCreate
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
    public IEnumerable<CategoryDto> CategoryDtos { get; set; } = new List<CategoryDto>(); 
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

        PostDto = new PostDto { Title = "", Description = "", Category = new CategoryDto { Id = Guid.Empty, FullName = ""},
            Tags = new HashSet<TagDto> {new TagDto{Id = Guid.Empty, Description = "" }} };
        
        CategoryId = PostDto.Category.ToString();
        SelectedTagDtos = PostDto.Tags;
    }

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        var createPostDto = new CreatePostDto
        {
            Title = PostDto.Title,
            Description = PostDto.Description,
            CategoryId = Guid.Parse(CategoryId),
            Tags = SelectedTagDtos.Select(tagDto => tagDto.Id).ToList()
        };

        var isAddedPost = await PostDataService.AddPostAsync(createPostDto);
        if (isAddedPost)
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
        NavigationManager.NavigateTo("/postoverview");
    }
}
