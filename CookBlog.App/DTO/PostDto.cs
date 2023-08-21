namespace CookBlog.App.DTO;

public class PostDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public CategoryDto? Category { get; set; }
    public IEnumerable<TagDto>? Tags { get; set; }
  //  public HashSet<CommentDto>? Comments { get; set; } = new HashSet<CommentDto>();
}
