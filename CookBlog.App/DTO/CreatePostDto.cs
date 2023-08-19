namespace CookBlog.App.DTO;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
 //   public Guid UserId { get; set; }
    public IEnumerable<Guid> Tags { get; set; }
}
