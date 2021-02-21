using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class VendorController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVendorService vendor;

        public VendorController(UserManager<ApplicationUser> userManager,
                                IVendorService vendor)
        {
            this.userManager = userManager;
            this.vendor = vendor;
        }

        public async Task<IActionResult> Index()
        {
            var userId = await this.userManager.GetUserAsync(this.User);

            //var vendor = new VendorsViewModel
            //{
            //   Products = this.vendor.VendorList<VendorViewModel>(userId.Id),
            //};
            var vend = this.vendor.AllProductInCart<VendorViewModel>(userId.Id);
            //  var productsInVendorList = this.vendor.VendorList<VendorViewModel>(userId.Id);

            return this.View(vend);
        }

        public async Task<IActionResult> AddToVendor(int productId)
        {
            var userId = await this.userManager.GetUserAsync(this.User);

            var product = await this.vendor.AddProductToVendor(productId, userId.Id);

            return this.Ok();
        }
    }
}
