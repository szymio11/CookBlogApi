namespace CookBlog.Api.Application.DTO;

public class CommentDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Description { get; set; }
}
