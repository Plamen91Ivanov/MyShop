using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services.Data
{
    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Product> product;
        private readonly IDeletableEntityRepository<ApplicationUser> user;

        public SearchService(IDeletableEntityRepository<Product> product,
                             IDeletableEntityRepository<ApplicationUser> user)
        {
            this.product = product;
            this.user = user;
        }

        public IEnumerable<T> Search<T>(string search, string region)
        {
            var result = this.product.All().Where(x => x.Name.Contains(search) && x.Location == region).To<T>().ToList();
            return result;
        }

        public IEnumerable<T> SearchUser<T>(string name)
        {
            var result = this.user.All().Where(x => x.UserName.Contains(name)).To<T>().ToList();
            return result;
        }

    }
}
