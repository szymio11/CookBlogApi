using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class DeleteTagHandler : ICommandHandler<DeleteTag>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagHandler(ITagRepository tagRepository) 
        => _tagRepository = tagRepository;

    public async Task HandleAsync(DeleteTag command)
    {
        var tagId = new TagId(command.TagId);
        var tag = await _tagRepository.GetAsync(tagId);

        if (tag is null)
        {
            throw new NotFoundTagException();
        }

        _tagRepository.DeleteAsync(tag);
    }
}
