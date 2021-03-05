using Microsoft.AspNetCore.Mvc;
using Shop.Services.Data;
using Shop.Web.ViewModels.Category;
using Shop.Web.ViewModels.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categories;
        private readonly IProductCreateService product;

        public CategoriesController(ICategoriesService categories,
                                    IProductCreateService product)
        {
            this.categories = categories;
            this.product = product;
        }

        public IActionResult ByName(string name)
        {
            var products = this.categories.ProductsByCategory<CategoriesViewModel>(name);
            products.Products = this.product.GetByCategory<ProductInputModel>(products.Id);

            return this.View(products);
        }
    }
}
