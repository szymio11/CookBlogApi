using System.ComponentModel.DataAnnotations;

namespace CookBlog.App.DTO;

public record CategoryDto
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = $"Full name is too long")]
    public string? FullName { get; set; }
}
