namespace CookBlog.Api.Application.DTO;

public record CategoryDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
}
