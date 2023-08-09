using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class UpdateTagHandler : ICommandHandler<UpdateTag>
{
    private readonly ITagRepository _tagRepository;

    public UpdateTagHandler(ITagRepository tagRepository) 
        => _tagRepository = tagRepository;

    public async Task HandleAsync(UpdateTag command)
    {
        var tagId = new TagId(command.TagId);
        var tag = await _tagRepository.GetAsync(tagId);

        if (tag is null)
        {
            throw new NotFoundTagException();
        }

        tag.Update(command.Description);
    }
}
