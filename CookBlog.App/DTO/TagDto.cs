namespace CookBlog.App.DTO;

public record TagDto
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
}

