using CookBlog.App.DTO;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components;

namespace CookBlog.App.Components;

public partial class AddTagDialog
{
    [Inject]
    public ITagDataService TagDataService { get; set; }

    [Parameter]
    public EventCallback<bool> CloseEventCallBack { get; set; }
    public CreateTagDto CreateTagDto { get; set; } = new CreateTagDto { Description = ""};

    public bool ShowDialog { get; set; }

    public void Show()
    {
        ResetDialog();
        ShowDialog = true;
        StateHasChanged();
    }  
    
    public void Close()
    {
        ShowDialog = false;
        StateHasChanged();
    }

    private void ResetDialog()
    {
        CreateTagDto = new CreateTagDto { Description = "" };
    }

    protected async Task HandleValidSubmit()
    {
        await TagDataService.AddTagAsync(CreateTagDto);
        ShowDialog = false;

        await CloseEventCallBack.InvokeAsync(true);
        StateHasChanged();
    }
}
