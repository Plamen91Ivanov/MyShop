using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Create
{
    public class ProductsInputModel : IMapFrom<Product>
    {
        public IEnumerable<ProductInputModel> Products { get; set; }
    }
}
