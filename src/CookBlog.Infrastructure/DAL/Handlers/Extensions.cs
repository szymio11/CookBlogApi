using CookBlog.Api.Application.DTO;
using CookBlog.Api.Core.Entities;
using System.Linq.Expressions;

namespace CookBlog.Api.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static Expression<Func<Category, CategoryDto>> AsCategoryDto()
    {
        return c => new CategoryDto
        {
            Id = c.Id,
            FullName = c.FullName
        };
    }

    public static Expression<Func<Tag, TagDto>> AsTagDto()
    {
        return t => new TagDto
        {
            Id = t.Id,
            Description = t.Description,
        };
    }

    public static Expression<Func<User, UserDto>> AsUserDto()
    {
        return u => new UserDto
        {
            Id = u.Id,
            UserName = u.UserName,
            FullName = u.FullName
        };
    }

    public static Expression<Func<Post, PostDto>> AsPostDto()
    {
        return p => new PostDto
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Tags = p.Tags.Select(t => new TagDto { Id = t.Id, Description = t.Description }).ToHashSet(),
            Comments = p.Comments.Select(c => new CommentDto { Id = c.Id, FullName = c.FullName, Description = c.Description }).ToHashSet(),
            Category = new CategoryDto { Id = p.Category.Id, FullName = p.Category.FullName }
        };
    }
}
