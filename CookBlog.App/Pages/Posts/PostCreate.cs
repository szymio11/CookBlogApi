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
    public CreatePostDto CreatePostDto { get; set; } = new CreatePostDto();  
    public List<CategoryDto> CategoryDtos { get; set; } = new List<CategoryDto>(); 
    public List<TagDto> TagDtos { get; set; } = new List<TagDto>(); 

    protected string CategoryId = string.Empty; 
    protected List<string> TagIds = new List<string>(); 

    protected string Message = string.Empty; 
    protected string StatusClass = string.Empty; 
    protected bool Saved;  

    protected override async Task OnInitializedAsync()
    {
        Saved = false;
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
        TagDtos = (await TagDataService.GetTagsAsync()).ToList();

        CreatePostDto = new CreatePostDto { Title = "", Description = "" };

        CategoryId = CreatePostDto.CategoryId.ToString();
        TagIds = CreatePostDto.Tags.Select(tagId => tagId.ToString()).ToList();
    }

    protected async Task HandleValidSubmit()
    {
        Saved = false;
        CreatePostDto.CategoryId = Guid.Parse(CategoryId);
        CreatePostDto.Tags = TagIds.Select(tagId => Guid.Parse(tagId));

        var isAddedPost = await PostDataService.AddPostAsync(CreatePostDto);
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
