using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Vendor
{
    public class VendorViewModel : IMapFrom<CardVendor>
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
