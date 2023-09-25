namespace CookBlog.App.DTO;

public class CreateCommentDto
{
    public string? FullName { get; set; }
    public string? Description { get; set; }
    public Guid PostId { get; set; }
}
