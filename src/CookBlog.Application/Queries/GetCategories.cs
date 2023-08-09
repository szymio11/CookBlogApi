using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.DTO;

namespace CookBlog.Api.Application.Queries;

public record GetCategories() : IQuery<IEnumerable<CategoryDto>>;
