using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public class CardService : ICardService
    {
        private readonly IDeletableEntityRepository<CartProduct> cardProduct;

        public CardService(IDeletableEntityRepository<CartProduct> cardProduct)
        {
            this.cardProduct = cardProduct;
        }

        public bool IsContained(int productId, string userId)
        {
            var product = this.cardProduct.All().Where(x => x.ProductId == productId && x.UserId == userId).FirstOrDefault();

            if (product != null)
            {
                return true;
            }

            return false;
        }

        public async Task<int> AddProductToCart(int id, string userId)
        {
            CartProduct product = new CartProduct
            {
                ProductId = id,
                UserId = userId,
            };

            await this.cardProduct.AddAsync(product);
            await this.cardProduct.SaveChangesAsync();

            return product.Id;
        }

        public int ProductCount(string userId)
        {
            var count = this.cardProduct.All().Where(x => x.UserId == userId).Count();

            return count;
        }
    }
}
