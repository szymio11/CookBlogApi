using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog.Api.Controllers;

[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommandHandler<CreateComment> _createCommentHandler;
    private readonly ICommandHandler<DeleteComment> _deleteCommentHandler;
    private readonly ICommandHandler<UpdateComment> _updateCommentHandler;

    public CommentController(ICommandHandler<CreateComment> createCommentHandler,
        ICommandHandler<DeleteComment> deleteCommentHandler,
        ICommandHandler<UpdateComment> updateCommentHandler)
    {
        _createCommentHandler = createCommentHandler;
        _deleteCommentHandler = deleteCommentHandler;
        _updateCommentHandler = updateCommentHandler;
    }

    [HttpPost("comment")]
    public async Task<ActionResult> Post(CreateComment command)
    {
        await _createCommentHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpDelete("comment/{commentId:guid}")]
    public async Task<ActionResult> Delete(Guid commentId)
    {
        await _deleteCommentHandler.HandleAsync(new DeleteComment(commentId));
        return NoContent();
    }

    [HttpPut("comment/{commentId:guid}")]
    public async Task<ActionResult> Put(Guid commentId, UpdateComment command)
    {
        await _updateCommentHandler.HandleAsync(command with { CommentId = commentId });
        return NoContent();
    }
}
