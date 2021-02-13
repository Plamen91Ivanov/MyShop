using Microsoft.AspNetCore.Mvc;
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

        public PostController(IProductCreateService product)
        {
            this.product = product;
        }

        //    [HttpPut("{id}")]
        //  [HttpGet(Name = "All")]
        [HttpGet("{id:int}")]
        //    [Route("id")]
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
