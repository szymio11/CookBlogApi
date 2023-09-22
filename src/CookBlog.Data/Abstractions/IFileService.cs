using CookBlog.Api.Core.ValuesObjects;
using Microsoft.AspNetCore.Http;

namespace CookBlog.Core.Abstractions;

public interface IFileService
{
    Task<ImagePath> ChangeImagePathAsync(IFormFile file);
}
