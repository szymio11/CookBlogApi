using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class CreateCommentHandler : ICommandHandler<CreateComment>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CreateCommentHandler(ICommentRepository commentRepository,
        IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    public async Task HandleAsync(CreateComment command)
    {
        var postId = new PostId(command.PostId);
        var post = await _postRepository.AnyAsync(postId);

        if (post is false)
        {
            throw new NotFoundPostException(postId);
        }

        var comment = Comment.Create(command.FullName, command.Description, command.PostId);

        await _commentRepository.AddAsync(comment);
    }
}
