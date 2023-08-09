using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Commands;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog.Api.Controllers;

[ApiController]
//[Authorize]
public class TagController : ControllerBase
{
    private readonly ICommandHandler<CreateTag> _createTagHandler;
    private readonly IQueryHandler<GetTag, TagDto> _getTagHandler;
    private readonly ICommandHandler<DeleteTag> _deleteTagHandler;
    private readonly IQueryHandler<GetTags, IEnumerable<TagDto>> _getTagsHandler;
    private readonly ICommandHandler<UpdateTag> _updateTagHandler;

    public TagController(ICommandHandler<CreateTag> createTagHandler,
        ICommandHandler<UpdateTag> updateTagHandler,
        ICommandHandler<DeleteTag> deleteTagHandler,
        IQueryHandler<GetTag, TagDto> getTagHandler,
        IQueryHandler<GetTags, IEnumerable<TagDto>> getTagsHandler)
    {
        _createTagHandler = createTagHandler;
        _getTagHandler = getTagHandler;
        _deleteTagHandler = deleteTagHandler;
        _getTagsHandler = getTagsHandler;
        _updateTagHandler = updateTagHandler;
    }

    [HttpPost("tag")]
    public async Task<ActionResult> Post(CreateTag command)
    {
        await _createTagHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpDelete("tag/{tagId}")]
    public async Task<ActionResult> Delete(Guid tagId)
    {
        await _deleteTagHandler.HandleAsync(new DeleteTag(tagId));
        return NoContent();
    }

    [HttpPut("tag/{tagId}")]
    public async Task<ActionResult> Put(Guid tagId, UpdateTag command)
    {
        await _updateTagHandler.HandleAsync(command with { TagId = tagId });
        return NoContent();
    }

    [HttpGet("tag/{tagId}")]
    public async Task<ActionResult<TagDto>> GetId(Guid tagId) 
        => Ok(await _getTagHandler.HandleAsync(new GetTag(tagId)));

    [HttpGet("tags")]
    public async Task<ActionResult<IEnumerable<TagDto>>> GetAll([FromQuery] GetTags query) 
        => Ok(await _getTagsHandler.HandleAsync(query));
}