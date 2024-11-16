namespace API.IServices;

public interface IUploadImageService
{
    Task<string?> UploadImage(IFormFile? image);
}