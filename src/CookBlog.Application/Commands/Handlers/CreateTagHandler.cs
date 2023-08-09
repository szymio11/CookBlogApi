using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;

namespace CookBlog.Api.Application.Commands.Handlers;

public sealed class CreateTagHandler : ICommandHandler<CreateTag>
{
    private readonly ITagRepository _tagRepository;

    public CreateTagHandler(ITagRepository tagRepository)
        => _tagRepository = tagRepository;

    public async Task HandleAsync(CreateTag command)
    {
        var tag = Tag.Create(command.Description);

        await _tagRepository.AddAsync(tag);
    }
}
