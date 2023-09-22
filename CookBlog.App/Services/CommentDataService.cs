using CookBlog.App.DTO;
using System.Net.Http.Json;

namespace CookBlog.App.Services;

public class CommentDataService : ICommentDataService
{
    private readonly HttpClient _httpClient;

    public CommentDataService(HttpClient httpClient) 
        => _httpClient = httpClient;

    public async Task AddCommentAsync(CreateCommentDto createCommentDto)
    {
        var response = await _httpClient.PostAsJsonAsync("comment", createCommentDto);
    }
}
