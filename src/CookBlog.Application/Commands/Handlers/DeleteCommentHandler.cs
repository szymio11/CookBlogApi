using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class DeleteCommentHandler : ICommandHandler<DeleteComment>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentHandler(ICommentRepository commentRepository) 
        => _commentRepository = commentRepository;

    public async Task HandleAsync(DeleteComment command)
    {
        var commentId = new CommentId(command.CommentId);
        var comment = await _commentRepository.GetAsync(commentId);

        if (comment is null) 
        {
            throw new NotFoundCommentException(commentId);
        }

        _commentRepository.DeleteAsync(comment);
    }
}
