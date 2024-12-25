using Microsoft.AspNetCore.Http;

namespace Application.Services.ImageServices
{
    public interface IImageServices
    {
        Task<string> UploadImageAsync(IFormFile image, string fileName, string folderName);
    }
}
