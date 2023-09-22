using CookBlog.App.DTO;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Json;

namespace CookBlog.App.Services;

public sealed class PostDataService : IPostDataService
{
    private readonly HttpClient _httpClient;

    public PostDataService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<bool> AddPostAsync(CreatePostDto createPostDto)
    {
        var response = await _httpClient.PostAsJsonAsync($"post", createPostDto);

        return response.IsSuccessStatusCode;
    }

    public async Task DeletePostAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"post/{id}");
    }

    public async Task<PostDto?> GetPostAsync(Guid id)
        => await _httpClient.GetFromJsonAsync<PostDto?>($"post/{id}");

    public async Task<IEnumerable<PostDto>?> GetPostsAsync()
        => await _httpClient.GetFromJsonAsync<IEnumerable<PostDto>?>("posts");

    public async Task UpdateImagePostAsync(Guid id, IBrowserFile file)
    {
        var stream = file.OpenReadStream();
        using var content = new MultipartFormDataContent();
        content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
        content.Add(new StreamContent(stream, (int)stream.Length), "file", file.Name);
        await _httpClient.PutAsync($"post/{id}/image", content);
    }

    public async Task<string?> GetImage(Guid id)
    {
        var response = await _httpClient.GetAsync($"post/{id}/image");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var imageBytes = await response.Content.ReadAsByteArrayAsync();
        var base64Image = Convert.ToBase64String(imageBytes);
        var contentType = response.Content.Headers.ContentType!.MediaType;
        return  $"data:{contentType};base64,{base64Image}";
    }

    public async Task UpdatePostAsync(Guid id, UpdatePostDto updatePostDto)
    {
        await _httpClient.PutAsJsonAsync($"post/{id}", updatePostDto);
    }
}
