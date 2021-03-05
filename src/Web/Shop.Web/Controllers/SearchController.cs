using Microsoft.AspNetCore.Mvc;
using Shop.Services.Data;
using Shop.Web.ViewModels.Create;
using Shop.Web.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchService search;

        public SearchController(ISearchService search)
        {
            this.search = search;
        }

        public IActionResult Index(string search)
        {
            ViewBag.Search = search;
            var result = new SearchViewModel
            {
                Products = this.search.Search<ProductInputModel>(search),
            };

            return this.View(result);
        }
    }
}
