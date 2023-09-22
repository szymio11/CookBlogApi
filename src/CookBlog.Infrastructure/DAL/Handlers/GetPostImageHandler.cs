using CookBlog.Api.Application.Abstractions;
using CookBlog.Api.Application.Exceptions;
using CookBlog.Api.Core.Exceptions;
using CookBlog.Api.Core.Repositories;
using CookBlog.Application.DTO;
using CookBlog.Application.Queries;
using CookBlog.Core.Exceptions;
using Microsoft.AspNetCore.StaticFiles;

namespace CookBlog.Infrastructure.DAL.Handlers;

public class GetPostImageHandler : IQueryHandler<GetPostImage, FileDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostImageHandler(IPostRepository postRepository) 
        => _postRepository = postRepository;

    public async Task<FileDto> HandleAsync(GetPostImage query)
    {
        var imagePath = await _postRepository.GetImagePathAsync(query.PostId);
        if (imagePath is null)
        {
            throw new InvalidImagePathException(imagePath);
        }

        await using var ms = new MemoryStream();
        await using var file = File.OpenRead(imagePath!);
        if (file is null)
        {
            throw new InvalidFileException(file.Name);
        }

        var provider = new FileExtensionContentTypeProvider();
        var fileName = Path.GetFileName(imagePath!);
        if (!provider.TryGetContentType(fileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }
        
        await file.CopyToAsync(ms);
        
        return new FileDto(ms.ToArray(), fileName, contentType);
    }
}