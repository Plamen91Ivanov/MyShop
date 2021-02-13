namespace Shop.Web.Controllers
{
    using System.Diagnostics;

    using Shop.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Shop.Services.Data;
    using Shop.Web.ViewModels.Create;

    public class HomeController : BaseController
    {
        private readonly IProductCreateService product;

        public HomeController(IProductCreateService product)
        {
            this.product = product;
        }

        public IActionResult Index()
        {
            var products = new ProductsInputModel()
            {
                Products = this.product.GetAllPromotedProducts<ProductInputModel>(),
            };

            return this.View(products);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
