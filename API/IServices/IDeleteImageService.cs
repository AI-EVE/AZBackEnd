namespace API.IServices;

public interface IDeleteImageService
{
    Task<bool> DeleteImage(string imageUrl);
}