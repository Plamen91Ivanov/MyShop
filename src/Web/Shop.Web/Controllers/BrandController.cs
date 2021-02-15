using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService brandService;
        private readonly UserManager<ApplicationUser> userManager;

        public BrandController(IBrandService brandService,
                               UserManager<ApplicationUser> userManager)
        {
            this.brandService = brandService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = await this.userManager.GetUserAsync(this.User);

            var brand = new BrandsViewModel
            {
                Brands = this.brandService.BrandsByUserId<BrandViewModel>(userId.Id),
            };
            return this.View(brand);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BrandViewModel brand, IFormFile logo)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var create = await this.brandService.Create(brand.Name, brand.Description, user.Id, logo);

            return this.RedirectToAction("Brand", new { id = create });
        }

        public IActionResult Brand(int id)
        {
            var brand = this.brandService.BrandById<BrandViewModel>(id);

            return this.View(brand);
        }

        public IActionResult Products(int id)
        {
            var products = this.brandService.AllProduct<BrandViewModel>(id);

            return this.View();
        }
        //user brands !
        //public IActionResult Brand()
        //{
        //    var allBrands = this.brandService.UserBrands();
        //}
    }
}
