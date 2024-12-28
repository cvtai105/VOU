using Application.Services.ImageServices;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class ImageServices : IImageServices
    {
        #region vars
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public ImageServices(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        public async Task<string> UploadImageAsync(IFormFile image, string fileName, string folderName)
        {
            Account account = new Account()
            {
                ApiKey = _config["Cloudinary:ApiKey"],
                ApiSecret = _config["Cloudinary:ApiSecret"],
                Cloud = _config["Cloudinary:Cloud"]
            };

            Cloudinary cloud = new Cloudinary(account);
            string imageUrl = "";

            ImageUploadResult result;
            using (var stream = image.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, stream),
                    Folder = folderName,
                    PublicId = fileName
                };

                result = await cloud.UploadAsync(uploadParams);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    imageUrl = result.SecureUrl.ToString();
                    return imageUrl;
                }
                else
                {
                    throw new Exception("Failed to upload image");
                }
            }
        }
    }
}
