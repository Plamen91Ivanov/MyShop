using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSearchController : ControllerBase
    {

        private readonly IProductCreateService product;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ApiSearchController(IProductCreateService product,
                              ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager)
        {
            this.product = product;
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet("{id::regex(^[[a-zA-ZА-Яа-я0-9]])}")]
        public async Task<ActionResult<IEnumerable<ProductInputModel>>> MostExpensive(string id)
        {
            var search = id.Split('-')[0];
            var region = id.Split('-')[1];
            var sortType = int.Parse(id.Split('-')[2]);

            var products = new ProductsInputModel()
            {
                Products = this.product.MostExpensive<ProductInputModel>(search,region, sortType),
            };

            //  var test = this.product.GetPromotedProductsById<ProductInputModel>(id, ItemsPerPage).ToList();

            return products.Products.ToList();
        }
    }
}
