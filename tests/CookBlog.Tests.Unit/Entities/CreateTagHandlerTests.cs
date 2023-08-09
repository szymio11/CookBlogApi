using CookBlog.Api.Application.Commands;
using CookBlog.Api.Application.Commands.Handlers;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Api.Tests.Unit.Entities;

public class CreateTagHandlerTests
{

    private readonly CreateTagHandler _createTagHandler;
    private readonly Mock<ITagRepository> _tagRepoMok = new Mock<ITagRepository>();

    public CreateTagHandlerTests()
    {
        _createTagHandler = new CreateTagHandler(_tagRepoMok.Object);
    }

    [Fact]
    public void Handle_Should_Create_Tag()
    {
        //Arrange
        var createTag = new CreateTag(new Description("słabe"));

        //Act
        var result = _createTagHandler.HandleAsync(createTag);

        //Assert
        result.Should().NotBeNull();
        _tagRepoMok.Verify(x => x.AddAsync(It.IsAny<Tag>()), Times.Exactly(1));
    }
}
