using Shop.Data.Models;
using Shop.Services.Mapping;
using Shop.Web.ViewModels.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Search
{
    public class SearchViewModel : IMapFrom<Product>
    {
        public IEnumerable<ProductInputModel> Products { get; set; }
    }
}
