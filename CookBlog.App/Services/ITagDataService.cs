using CookBlog.App.DTO;

namespace CookBlog.App.Services;

public interface ITagDataService
{
    Task<TagDto?> GetTagAsync(Guid id);
    Task<IEnumerable<TagDto>> GetTagsAsync();
    Task<bool> AddTagAsync(CreateTagDto createTagDto);
    Task DeleteTagAsync(Guid id);
    Task UpdateTagAsync(Guid id, UpdateTagDto updateTagDto);
}
