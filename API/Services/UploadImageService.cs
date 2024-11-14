using System;
using API.IServices;

namespace API.Services;

public class UploadImageService : IUploadImageService
{
    private readonly IBlobService _blobService;

    public UploadImageService(IBlobService blobService)
    {
        _blobService = blobService;
    }


    public async Task<string?> UploadImage(IFormFile? image)
    {
        string? logoUrl = null;

        if (image != null && image.Length != 0)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            using var stream = image.OpenReadStream();
            logoUrl = await _blobService.UploadImageAsync(stream, fileName);

            return logoUrl;
        }

        return logoUrl;
    }


}
