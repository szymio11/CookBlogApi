using CookBlog.Api.Application.Commands;
using CookBlog.Api.Application.Commands.Handlers;
using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.Repositories;
using CookBlog.Api.Core.ValuesObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace CookBlog.Api.Tests.Unit.Entities;

public class UpdateCategoryHandlerTests
{
    private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new Mock<ICategoryRepository>();

    public UpdateCategoryHandlerTests()
    {
        _categoryRepositoryMock = new Mock<ICategoryRepository>();
    }

    [Fact]
    public void Handle_Should_Return_Update_Category()
    {
        //Arrange
        var update = new UpdateCategory(Guid.NewGuid(), "Vegetable");
        var updateHandle = new UpdateCategoryHandler(_categoryRepositoryMock.Object);
        _categoryRepositoryMock.Setup(x => x.GetAsync(It.IsAny<CategoryId>())).ReturnsAsync(new Category());

        //Act
        var result = updateHandle.HandleAsync(update);

        //Assert
        result.Should().NotBeNull();
        _categoryRepositoryMock.Verify(x => x.GetAsync(It.IsAny<CategoryId>()), Times.Once);
    }

    [Fact]
    public void Method_Should_Update_Category()
    {
        //Arrange
        var category = Category.Create(new FullName("Fruits"));
        var newFullName = new FullName("Vegetable");

        //Act
        category.Update(newFullName);

        //Assert
        category.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_Should_Return_Fail_Update_Category()
    {
        //Arrange
        var update = new UpdateCategory(Guid.NewGuid(), "Vegetable");
        var updateHandler = new UpdateCategoryHandler(_categoryRepositoryMock.Object);

        //Act
        var exception = await Record.ExceptionAsync(() => updateHandler.HandleAsync(update));

        //Assert
        exception.Should().NotBeNull(); 

    }
}
