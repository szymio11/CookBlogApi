using CookBlog.Api.Core.Entities;
using CookBlog.Api.Core.ValuesObjects;
using FluentAssertions;
using Xunit;

namespace CookBlog.Api.Tests.Unit.Entities;

public class UpdatePostTests
{
    [Fact]
    public void Should_Update_New_Tag()
    {
        //Arrange
        var categoryId = new CategoryId(Guid.NewGuid());
        var userId = new UserId(Guid.NewGuid());
        var tags = new HashSet<Tag> { Tag.Create("słabe"), Tag.Create("świetne"), Tag.Create("mrożone") };
        var post = Post.Create("Sugar", "Note very sweet", categoryId, userId, tags);
        var newTags = new HashSet<Tag> { Tag.Create("mrożone") };

        //Act
        post.Update("Salt", "Note very salty", categoryId, newTags);

        //Assert           
        post.Should().NotBeNull();
        post.Title.Should().NotBeNull();
        post.Description.Should().NotBeNull();
        post.CategoryId.Should().Be(categoryId);
        post.UserId.Should().Be(userId);
        post.Tags.Select(x => x.Id).First().Should().Be(newTags.First().Id);
    }

    [Fact]
    public void Should_Update_List_Tags()
    {
        //Arrange
        var tags = new HashSet<Tag> { Tag.Create("pyszne") };
        var post = Post.Create("Sugar", "Note very sweet", Guid.NewGuid(), Guid.NewGuid(), tags);
        var newTags = new HashSet<Tag> { Tag.Create("mrożone"), Tag.Create("tragedia") };

        //Act
        post.Update("Salt", "Note very salty", Guid.NewGuid(), newTags);

        //Assert
        post.Tags.Should().BeEquivalentTo(newTags);
    }

    [Fact]
    public void Should_Update_New_Tag_And_Return_List_All_Tags()
    {
        //Arrange
        var tags = new HashSet<Tag> { Tag.Create("pyszne") };
        var post = Post.Create("Sugar", "Note very sweet", Guid.NewGuid(), Guid.NewGuid(), tags);
        var newTags = new HashSet<Tag> { tags.First(), Tag.Create("tragedia") };

        //Act
        post.Update("Salt", "Note very salty", Guid.NewGuid(), newTags);

        //Assert
        post.Tags.Should().BeEquivalentTo(newTags);
    }
}
