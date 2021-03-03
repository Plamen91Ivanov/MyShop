using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> category;

        public CategoriesService(IDeletableEntityRepository<Category> category)
        {
            this.category = category;
        }

        public T ProductsByCategory<T>(string name)
        {
            var products = this.category.All().Where(x => x.Name == name).To<T>().FirstOrDefault();
            return products;
        }
    }
}
