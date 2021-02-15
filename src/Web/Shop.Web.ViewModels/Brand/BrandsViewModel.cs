using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Brand
{
    public class BrandsViewModel : IMapFrom<Shop.Data.Models.Brand>
    {
        public IEnumerable<BrandViewModel> Brands { get; set; }
    }
}
