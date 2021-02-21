using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Vendor
{
    public class VendorsViewModel : IMapFrom<CardVendor>
    {
        public IEnumerable<VendorViewModel> Products { get; set; }
    }
}
