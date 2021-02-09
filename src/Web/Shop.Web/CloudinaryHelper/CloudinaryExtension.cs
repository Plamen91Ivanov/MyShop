using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.CloudinaryHelper
{
    public class CloudinaryExtension
    {
        public static async Task UploadAsync(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var upload = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream),
                    };
                    var result = await cloudinary.UploadAsync(upload);
                    var test = result.Uri.AbsoluteUri;
                }
            }
        }
    }
}
