using API.IServices;

namespace API.Services;

public class DeleteImageService : IDeleteImageService
{
    private readonly IBlobService _blobService;

    public DeleteImageService(IBlobService blobService)
    {
        _blobService = blobService;
    }


    public Task<bool> DeleteImage(string imageUrl)
    {
        return _blobService.DeleteImageAsync(imageUrl);
    }
}