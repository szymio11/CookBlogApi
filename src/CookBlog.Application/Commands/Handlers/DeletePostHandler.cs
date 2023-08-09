using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class DeletePostHandler : ICommandHandler<DeletePost>
{
    private readonly IPostRepository _postRepository;

    public DeletePostHandler(IPostRepository postRepository) 
        => _postRepository = postRepository;

    public async Task HandleAsync(DeletePost command)
    {
        var postId = new PostId(command.PostId);
        var post = await _postRepository.GetAsync(postId);

        if (post is null)
        {
            throw new NotFoundPostException(postId);
        }

        _postRepository.DeleteAsync(post);
    }
}
