using CookBlog.Api.Application.Queries;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using CookBlog.Api.Infrastructure.DAL.Handlers;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Api.Tests.Unit.Entities;

public class GetTagHandlerTests
{
    private readonly GetTagHandler _getTagHandler;
    private readonly Mock<ITagRepository> _tagRepoMok = new Mock<ITagRepository>();

    public GetTagHandlerTests()
    {
        _getTagHandler = new GetTagHandler(_tagRepoMok.Object);
    }

    [Fact]
    public async Task Handle_Should_Return_Tag_Get_By_Id()
    {
        //Arrange
        var getTag = new GetTag(new TagId(Guid.NewGuid()));
        var tag = new Tag { Id = new TagId(Guid.NewGuid()), Description = new Description("Pycha") };
        _tagRepoMok.Setup(x => x.GetAsync(It.IsAny<TagId>())).ReturnsAsync(tag);

        //Act
        var result = await _getTagHandler.HandleAsync(getTag);

        //Assert
        _tagRepoMok.Verify(x => x.GetAsync(It.IsAny<TagId>()), Times.Exactly(1));
        result.Should().NotBeNull();
        result.Id.Should().Be(tag.Id);
        result.Description.Should().Be(tag.Description);
    }

    [Fact]
    public async Task Handle_Should_Return_Fail_Get_Tag()
    {
        //Arrange
        var tagId = new TagId(Guid.NewGuid());
        var getTag = new GetTag(tagId);

        //Act
        var exception = await Record.ExceptionAsync(() => _getTagHandler.HandleAsync(getTag));

        //Assert
        exception.Should().NotBeNull(); 
    }
}
