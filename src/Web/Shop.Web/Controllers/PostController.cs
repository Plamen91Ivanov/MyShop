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
    public class PostController : ControllerBase
    {

        private const int ItemsPerPage = 4;

        private readonly IProductCreateService product;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IProductCreateService product,
                              ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager)
        {
            this.product = product;
            this.context = context;
            this.userManager = userManager;
        }

       
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProductInputModel>>> AllOrderedByCreatedOnAscending(int id)
        {
            var products = new ProductsInputModel()
            {
                Products = this.product.GetPromotedProductsById<ProductInputModel>(id, ItemsPerPage),
            };

            //  var test = this.product.GetPromotedProductsById<ProductInputModel>(id, ItemsPerPage).ToList();

            return products.Products.ToList();
        }
    }
}
