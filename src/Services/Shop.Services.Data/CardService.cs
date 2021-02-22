using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
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
    }
}
