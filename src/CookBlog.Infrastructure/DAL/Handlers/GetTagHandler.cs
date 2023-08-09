using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Application.Queries;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

public sealed class GetTagHandler : IQueryHandler<GetTag, TagDto>
{
    private readonly ITagRepository _tagRepository;

    public GetTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<TagDto> HandleAsync(GetTag query)
    {
        var tagId = new TagId(query.TagId);
        var tag = await _tagRepository.GetAsync(tagId);
        if (tag is null)
        {
            throw new NotFoundTagException();
        }

        return new TagDto { Id = tag.Id, Description = tag.Description };
    }
}