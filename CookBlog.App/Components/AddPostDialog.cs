using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CookBlog.App.Components;

public partial class AddPostDialog
{
    [Inject]
    public IPostDataService PostDataService { get; set; }
    [Inject]
    public ITagDataService TagDataService { get; set; }
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    [Parameter]
    public EventCallback<bool> CloseEventCallBack { get; set; }
    [CascadingParameter] 
    MudDialogInstance MudDialog { get; set; }

    protected CategoryDto Category;
    public PostDto PostDto { get; set; } = new PostDto();
    public IEnumerable<TagDto> TagDtos { get; set; } = new List<TagDto>();
    public IEnumerable<TagDto> SelectedTagDtos { get; set; } = new List<TagDto>();
    public IEnumerable<CategoryDto> CategoryDtos { get; set; } = new List<CategoryDto>();

    protected override async Task OnInitializedAsync()
    {
        CategoryDtos = (await CategoryDataService.GetCategoriesAsync()).ToList();
        TagDtos = (await TagDataService.GetTagsAsync()).ToList();
    }

    protected async Task HandleValidSubmit()
    {
        var createPostDto = new CreatePostDto
        {
            Title = PostDto.Title,
            Description = PostDto.Description,
            CategoryId = Category.Id,
            Tags = SelectedTagDtos.Select(x => x.Id).ToList()
        };
        await PostDataService.AddPostAsync(createPostDto);

        await CloseEventCallBack.InvokeAsync(true);
        StateHasChanged();
        MudDialog.Close(DialogResult.Ok(true));
    }

    void Cancel()
    {
        MudDialog.Cancel();
        StateHasChanged();
    }
}
