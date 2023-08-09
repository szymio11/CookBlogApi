using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class UpdatePostHandler : ICommandHandler<UpdatePost>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdatePostHandler(IPostRepository postRepository,
        ITagRepository tagRepository, ICategoryRepository categoryRepository)
    {

        _postRepository = postRepository;
        _tagRepository = tagRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task HandleAsync(UpdatePost command)
    {
        var postId = new PostId(command.PostId);
        var post = await _postRepository.GetAsync(postId);
        if (post is null)
        {
            throw new NotFoundPostException(postId);
        }

        var categoryId = new CategoryId(command.CategoryId);
        var category = await _categoryRepository.GetAsync(categoryId);
        if (category is null) 
        {
            throw new NotFoundCategoryException(categoryId);
        }

        var tags = await _tagRepository.GetTags(command.Tags);
        if(!tags.Any())
        {
            throw new NotFoundTagException();
        }

        post.Update(command.Title, command.Description, command.CategoryId, tags.ToHashSet());
    }
}
