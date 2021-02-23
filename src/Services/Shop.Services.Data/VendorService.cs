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
        private readonly IDeletableEntityRepository<CartProduct> cartProduct;
        private readonly IDeletableEntityRepository<Cart> cart;
        private readonly IDeletableEntityRepository<Product> product;

        public VendorService(IDeletableEntityRepository<CardVendor> vendor,
                             IDeletableEntityRepository<CartProduct> cartProduct,
                             IDeletableEntityRepository<Cart> cart,
                             IDeletableEntityRepository<Product> product)
        {
            this.vendor = vendor;
            this.cartProduct = cartProduct;
            this.cart = cart;
            this.product = product;
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
            //var cartId = this.cart.All().Where(x => x.UserId == userId)
            //  .FirstOrDefault();

            var tests = this.cartProduct.All().Where(x => x.UserId == userId).ToList();
            var test = new HashSet<int>();

            foreach (var item in tests)
            {
                test.Add(item.ProductId);
            }

            test.Distinct();

            var products = new List<T>();

            foreach (var item in test)
            {
                var product = this.product.All().Where(x => x.Id == item)
                   .To<T>().FirstOrDefault();

                products.Add(product);
            }

            return products;
        }

        public T AllProductInCart<T>(string id)
        {
            var products = this.vendor.All().Where(x => x.UserId == id).To<T>().FirstOrDefault();

            return products;
        }

        public async Task<int> Delete(int id)
        {
            var deleteProduct = this.cartProduct.All().Where(x => x.ProductId == id).FirstOrDefault();
            deleteProduct.IsDeleted = true;

            await this.cartProduct.SaveChangesAsync();

            return deleteProduct.Id;
        }
    }
}
