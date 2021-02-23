using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface ICardService
    {
       Task<int> AddProductToCart(int id, string userId);

       bool IsContained(int productId, string userId);

       int ProductCount(string userId);

    }
}
