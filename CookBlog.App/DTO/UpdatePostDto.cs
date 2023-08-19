namespace CookBlog.App.DTO;

public class UpdatePostDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public IEnumerable<Guid>? Tags { get; set; }
}