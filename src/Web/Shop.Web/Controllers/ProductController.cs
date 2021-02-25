using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductCreateService product;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductController(IProductCreateService product,
                                 UserManager<ApplicationUser> userManager)
        {
            this.product = product;
            this.userManager = userManager;
        }

        public IActionResult ProductByName(string name)
        {
            var product = this.product.GetByName<ProductInputModel>(name);
            var count = this.product.Count(name);
            return this.View(product);
        }

        public IActionResult Product(int id)
        {
            var productViewModel = this.product.GetById<ProductInputModel>(id);
            return this.View(productViewModel);
        }

        public IActionResult MyProducts()
        {
            var user = this.userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
            var productsViewModel = new ProductsInputModel();
            productsViewModel.Products = this.product.GetUserProducts<ProductInputModel>(user.Id);
            return this.View(productsViewModel);
        }
    }
}
