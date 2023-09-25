namespace CookBlog.App.DTO;

public class PostDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public CategoryDto? Category { get; set; }
    public IEnumerable<TagDto>? Tags { get; set; } = new List<TagDto>();
    public IEnumerable<CommentDto>? Comments { get; set; } = new List<CommentDto>();
}
