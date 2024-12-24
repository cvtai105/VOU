using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageServices
{
    public interface IImageServices
    {
        Task<string> UploadImageAsync(IFormFile image, string fileName, string folderName);
    }
}
