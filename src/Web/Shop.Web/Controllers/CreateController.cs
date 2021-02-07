using Microsoft.AspNetCore.Mvc;
using Shop.Services.Data;
using Shop.Web.ViewModels.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class CreateController : BaseController
    {
        private readonly IProductCreateService product;

        public CreateController(IProductCreateService product)
        {
            this.product = product;
        }

        public IActionResult ProductCreate()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ProductInputModel productInputModel)
        {
            var createProduct =
                this.product.Create(
                    productInputModel.Name,
                    productInputModel.Description,
                    productInputModel.Price,
                    productInputModel.Location,
                    productInputModel.Image);

            return Redirect
        }
    }
}
