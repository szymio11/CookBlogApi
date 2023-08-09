using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Commands;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog.Api.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    private readonly ICommandHandler<CreatePost> _createPostHandler;
    private readonly IQueryHandler<GetPost, PostDto> _getPostHandler;
    private readonly IQueryHandler<GetPosts, IEnumerable<PostDto>> _getPostsHandler;
    private readonly ICommandHandler<DeletePost> _deletePostHandler;
    private readonly ICommandHandler<UpdatePost> _updatePostHandler;

    public PostController(ICommandHandler<CreatePost> createPostHandler,
        ICommandHandler<DeletePost> deletePostHandler,
        ICommandHandler<UpdatePost> updatePostHandler,
        IQueryHandler<GetPost, PostDto> getPostHandler,
        IQueryHandler<GetPosts, IEnumerable<PostDto>> getPostsHandler)
    {
        _createPostHandler = createPostHandler;
        _getPostHandler = getPostHandler;
        _getPostsHandler = getPostsHandler;
        _deletePostHandler = deletePostHandler;
        _updatePostHandler = updatePostHandler;
    }

    [HttpPost("post")]
    public async Task<ActionResult> Post(CreatePost command)
    {
        await _createPostHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpDelete("post/{postId:guid}")]
    public async Task<ActionResult> Delete(Guid postId)
    {
        await _deletePostHandler.HandleAsync(new DeletePost(postId));
        return NoContent();
    }

    [HttpPut("post/{postId:guid}")]
    public async Task<ActionResult> Put(Guid postId, UpdatePost command)
    {
        await _updatePostHandler.HandleAsync(command with { PostId = postId});
        return NoContent();
    }

    [HttpGet("posts")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetAll([FromQuery] GetPosts query) 
        => Ok(await _getPostsHandler.HandleAsync(query));

    [HttpGet("post/{postId:guid}")]
    public async Task<ActionResult<PostDto>> GetId(Guid postId) 
        => Ok(await _getPostHandler.HandleAsync(new GetPost(postId)));

}