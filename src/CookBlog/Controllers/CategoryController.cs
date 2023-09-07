using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Commands;
using CookBlog.Api.Application.DTO;
using CookBlog.Api.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBlog.Api.Controllers;

[Authorize]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategory;
    private readonly IQueryHandler<GetCategory, CategoryDto> _getCategory;
    private readonly ICommandHandler<UpdateCategory> _updateCategory;
    private readonly ICommandHandler<DeleteCategory> _deleteCategory;
    private readonly IQueryHandler<GetCategories, IEnumerable<CategoryDto>> _getCategories;

    public CategoryController(ICommandHandler<CreateCategory> createCategory,
        ICommandHandler<UpdateCategory> updateCategory,
        ICommandHandler<DeleteCategory> deleteCategory,
        IQueryHandler<GetCategory, CategoryDto> getCategory,
        IQueryHandler<GetCategories, IEnumerable<CategoryDto>> getCategories)
    {
        _createCategory = createCategory;
        _getCategory = getCategory;
        _updateCategory = updateCategory;
        _deleteCategory = deleteCategory;
        _getCategories = getCategories;
    }

    [HttpPost("category")]
    public async Task<ActionResult> Post(CreateCategory command)
    {
        await _createCategory.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("category/{categoryId:guid}")]
    public async Task<ActionResult> Put(Guid categoryId, UpdateCategory command)
    {
        await _updateCategory.HandleAsync(command with { CategoryId = categoryId });
        return NoContent();
    }

    [HttpDelete("category/{categoryId:guid}")]
    public async Task<ActionResult> Delete(Guid categoryId)
    {
        await _deleteCategory.HandleAsync(new DeleteCategory(categoryId));
        return NoContent();
    }

    [HttpGet("category/{categoryId:guid}")]
    public async Task<ActionResult<CategoryDto>> GetId(Guid categoryId)
        => Ok(await _getCategory.HandleAsync(new GetCategory(categoryId)));

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll([FromQuery] GetCategories query) 
        => Ok(await _getCategories.HandleAsync(query));
}