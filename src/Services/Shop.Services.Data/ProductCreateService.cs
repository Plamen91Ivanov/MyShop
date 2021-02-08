using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public class ProductCreateService : IProductCreateService
    {
        private readonly IDeletableEntityRepository<Product> product;
        private readonly IDeletableEntityRepository<ProductImage> productImage;
        private readonly IDeletableEntityRepository<ImageProduct> imageProduct;

        public ProductCreateService(IDeletableEntityRepository<Product> product,
                                    IDeletableEntityRepository<ProductImage> productImage,
                                    IDeletableEntityRepository<ImageProduct> imageProduct)
        {
            this.product = product;
            this.productImage = productImage;
            this.imageProduct = imageProduct;
        }

        public async Task<int> CreateAsync(string name, string description, decimal price, string location, string userId)
        {
            Product product = new Product
            {
                UserId = userId,
                Name = name,
                Description = description,
                Price = price,
                Location = location,
            };

            await this.product.AddAsync(product);
            await this.product.SaveChangesAsync();

            return product.Id;
        }

        public async Task<int> CreateImage(ICollection<IFormFile> images, int id)
        {
            foreach (var image in images)
            {
                var img = new ImageProduct
                {
                    Name = image.FileName,
                    ProductId = id,
                };
                await this.imageProduct.AddAsync(img);
            }

            await this.imageProduct.SaveChangesAsync();

            return 1;
        }
    }
}
