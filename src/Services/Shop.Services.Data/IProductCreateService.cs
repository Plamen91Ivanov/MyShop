using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface IProductCreateService
    {
        Task<int> CreateAsync(string name, string description, decimal price, string location, string userId, IFormFile image, int brandId, string category);

        Task<int> CreateImage(ICollection<IFormFile> images, int id);

        T GetById<T>(int id);

        T GetByName<T>(string name);

        IEnumerable<T> GetByCategory<T>(int id);

        IEnumerable<T> GetAllPromotedProducts<T>();

        IEnumerable<T> GetPromotedProductsById<T>(int id, int itemsPerPage);

        IEnumerable<T> MostExpensive<T>(string id, string region, int number);

        IEnumerable<T> GetUserProducts<T>(string userId);

        Task<bool> Count(string name);
    }
}
