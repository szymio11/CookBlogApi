using CookBlog.Api.Application.Commands;
using CookBlog.Api.Application.Commands.Handlers;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Api.Tests.Unit.Entities;

public class CreateCategoryHandlerTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new Mock<ICategoryRepository>();

    public CreateCategoryHandlerTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
    }

    [Fact]
    public void Handle_Should_Return_Success_Create_Category()
    {
        //Arrange
        var create = new CreateCategory("Good Food");
        var createHandler = new CreateCategoryHandler(_categoryRepositoryMock.Object);
        _categoryRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Category>()));

        //Act
        var result = createHandler.HandleAsync(create);

        //Assert
        result.Should().NotBeNull();
        result.IsCompleted.Should().BeTrue();
        result.Id.Should().Be(result.Id);
        _categoryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public void Handle_Should_Return_Faulted_Create_Category()
    {
        //Arrange
        var create = new CreateCategory("Z");
        var createHandler = new CreateCategoryHandler(_categoryRepositoryMock.Object);
        _categoryRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Category>()));

        //Act
        var result = createHandler.HandleAsync(create);

        //Assert
        result.IsFaulted.Should().BeTrue();
        _categoryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Never);
    }
}
