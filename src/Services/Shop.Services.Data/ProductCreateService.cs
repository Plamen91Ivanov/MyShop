using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class ProductCreateService : IProductCreateService
    {
        private readonly IDeletableEntityRepository<Product> product;
        private readonly IDeletableEntityRepository<ProductImage> productImage;
        private readonly IDeletableEntityRepository<ImageProduct> imageProduct;
        private readonly Cloudinary cloudinary;

        public ProductCreateService(IDeletableEntityRepository<Product> product,
                                    IDeletableEntityRepository<ProductImage> productImage,
                                    IDeletableEntityRepository<ImageProduct> imageProduct,
                                    Cloudinary cloudinary)
        {
            this.product = product;
            this.productImage = productImage;
            this.imageProduct = imageProduct;
            this.cloudinary = cloudinary;
        }

        public IEnumerable<T> GetAllPromotedProducts<T>()
        {
            var promotedProduct = this.product.All().To<T>().ToList();
            return promotedProduct;
        }

        public async Task<int> CreateAsync(string name, string description, decimal price, string location, string userId, IFormFile image)
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

            Product product = new Product
            {
                UserId = userId,
                Name = name,
                Description = description,
                Price = price,
                Location = location,
                Image = imageName,
            };

            await this.product.AddAsync(product);
            await this.product.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> CreateImage(ICollection<IFormFile> images, int id)
        {
            foreach (var file in images)
            {
                byte[] destinationImage;
                string[] imagePath;
                var imageName = string.Empty;

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
                    var result = await this.cloudinary.UploadAsync(upload);
                    var test = result.Uri.AbsoluteUri;
                    imagePath = test.Split("upload/");
                    imageName = imagePath[1];

                }

                var img = new ImageProduct
                {
                    Name = imageName,
                    ProductId = id,
                };
                await this.imageProduct.AddAsync(img);
            }
            await this.imageProduct.SaveChangesAsync();

            return 1;
        }

        public T GetById<T>(int id)
        {
            var product = this.product.All().Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return product;
        }

        public T GetByName<T>(string name)
        {
            var product = this.product.All().Where(x => x.Name == name)
                .To<T>()
                .FirstOrDefault();

            return product;
        }

        public IEnumerable<T> GetUserProducts<T>(string userId)
        {
            var products = this.product.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.UserId == userId);

            return products.To<T>().ToList();
        }
    }
}
