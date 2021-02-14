using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public class BrandService : IBrandService
    {
        private readonly IDeletableEntityRepository<Brand> brand;
        private readonly Cloudinary cloudinary;

        public BrandService(IDeletableEntityRepository<Brand> brand,
                            Cloudinary cloudinary)
        {
            this.brand = brand;
            this.cloudinary = cloudinary;
        }

        public async Task<int> Create(string name, string description, string userId, IFormFile image)
        {

            byte[] destinationImage;
            string[] imagePath;
            var imageName = string.Empty;

            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var upload = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, destinationStream),
                };
                var result = await this.cloudinary.UploadAsync(upload);
                var imageUri = result.Uri.AbsoluteUri;
                imagePath = imageUri.Split("upload/");
                imageName = imagePath[1];
            }

            var brand = new Brand
            {
                Name = name,
                Description = description,
                Logo = imageName,
            };

            await this.brand.AddAsync(brand);
            await this.brand.SaveChangesAsync();

            return brand.Id;
        }

        public T BrandById<T>(int id)
        {
            var brand = this.brand.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return brand;
        }
    }
}
