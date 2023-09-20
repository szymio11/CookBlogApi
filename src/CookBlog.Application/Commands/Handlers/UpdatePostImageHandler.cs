using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Application.Commands.Handlers;

public class UpdatePostImageHandler : ICommandHandler<UpdatePostImage>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostImageHandler(IPostRepository postRepository) 
        => _postRepository = postRepository;

    public async Task HandleAsync(UpdatePostImage command)
    {
        var postId = new PostId(command.PostId);

        var post = await _postRepository.GetAsync(postId);
        if (post == null)
        {
            throw new NotFoundPostException(postId);
        }

        var imagePath = await _postRepository.ChangeImagePathAsync(command.FormFile);

        post.ChangeImage(imagePath);
    }
}
