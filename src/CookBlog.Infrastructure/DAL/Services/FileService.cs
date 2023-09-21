using CookBlog.Api.Core.ValuesObjects;
using CookBlog.Core.Abstractions;
using CookBlog.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace CookBlog.Infrastructure.DAL.Services;

internal sealed class FileService : IFileService
{
    private readonly IHostEnvironment _environment;
    private readonly ExtensionFileOptions _extensionFileOptions;

    public FileService(IHostEnvironment environment, 
        ExtensionFileOptions extensionFileOptions)
    {
        _environment = environment;
        _extensionFileOptions = extensionFileOptions;
    }

    public async Task<ImagePath> ChangeImagePathAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new InvalidFileException(file.FileName);

        var extension = Path.GetExtension(file.FileName);

        if (!_extensionFileOptions.AllowedExtensions.Contains(extension))
            throw new InvalidFileExtensionsException(file.FileName);

        var newFileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Images", newFileName);

        using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        {
            await file.CopyToAsync(fileStream);
        }

        return filePath;
    }
}
