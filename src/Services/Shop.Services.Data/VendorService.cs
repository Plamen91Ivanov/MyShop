using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public class VendorService : IVendorService
    {
        private readonly IDeletableEntityRepository<CardVendor> vendor;

        public VendorService(IDeletableEntityRepository<CardVendor> vendor)
        {
            this.vendor = vendor;
        }

        public async Task<int> AddProductToVendor(int productId, string userId)
        {
            var products = new CardVendor
            {
                UserId = userId,
                ProductId = productId,
            };
            await this.vendor.AddAsync(products);
            await this.vendor.SaveChangesAsync();

            return products.Id;
        }

        public IEnumerable<T> VendorList<T>(string userId)
        {
            var products = this.vendor.All().Where(x => x.UserId == userId).To<T>().ToList();
            return products;
        }

        public T AllProductInCart<T>(string id)
        {
            var products = this.vendor.All().Where(x => x.UserId == id).To<T>().FirstOrDefault();

            return products;
        }
    }
}
