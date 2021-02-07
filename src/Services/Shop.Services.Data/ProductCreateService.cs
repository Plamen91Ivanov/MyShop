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

        public ProductCreateService(IDeletableEntityRepository<Product> product)
        {
            this.product = product;
        }

        public async Task<int> Create()
        {

        }
    }
}
