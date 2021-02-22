using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Cart
{
    public class ProductCart : IMapFrom<Shop.Data.Models.ProductCart>
    {
        public int ProductId { get; set; }

        public int CartId { get; set; }
    }
}
