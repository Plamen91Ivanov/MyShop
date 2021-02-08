using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class CreateController : BaseController
    {
        private readonly IProductCreateService product;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateController(IProductCreateService product,
                                UserManager<ApplicationUser> userManager)
        {
            this.product = product;
            this.userManager = userManager;
        }

        public IActionResult ProductCreate()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(ProductInputModel productInputModel, ICollection<IFormFile> images)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var createProduct =
                await this.product.CreateAsync(
                    productInputModel.Name,
                    productInputModel.Description,
                    productInputModel.Price,
                    productInputModel.Location,
                    user.Id
                    );

            return this.RedirectToAction("ProductCreate");
        }

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> CreateImage(string test)
        //{ 
        //    var addImage = await this.product.CreateImage(test, 1);

        //    return this.RedirectToAction("ProductCreate");
        //}
    }
}
