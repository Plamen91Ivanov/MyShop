using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.CloudinaryHelper;
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
        private readonly Cloudinary cloudinary;

        public CreateController(IProductCreateService product,
                                UserManager<ApplicationUser> userManager,
                                Cloudinary cloudinary)
        {
            this.product = product;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }

        public IActionResult ProductCreate(int id)
        {
            this.ViewBag.BrandId = id;
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(ProductInputModel productInputModel, IFormFile image, ICollection<IFormFile> images, int brandId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var createProduct =
                await this.product.CreateAsync(
                    productInputModel.Name,
                    productInputModel.Description,
                    productInputModel.Price,
                    productInputModel.Location,
                    user.Id,
                    image,
                    brandId
                    );

            var img = await this.product.CreateImage(images, createProduct);
           // await CloudinaryExtension.UploadAsync(this.cloudinary, images);

            return this.RedirectToAction("Product", new {id = createProduct});
        }

        public IActionResult Product(int id)
        {
            var productViewModel = this.product.GetById<ProductInputModel>(id);
            return this.View(productViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            await CloudinaryExtension.UploadAsync(this.cloudinary, files);

            return Redirect("/");
        }
    }
}
