using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface IVendorService
    {
        IEnumerable<T> VendorList<T>(string userId);

        Task<int> AddProductToVendor(int productId, string userId);

        T AllProductInCart<T>(string id);

        Task<int> Delete(int id);
    }
}
