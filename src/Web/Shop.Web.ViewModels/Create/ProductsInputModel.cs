using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Create
{
    public class ProductsInputModel
    {
        public IEnumerable<ProductInputModel> Products { get; set; }
    }
}
