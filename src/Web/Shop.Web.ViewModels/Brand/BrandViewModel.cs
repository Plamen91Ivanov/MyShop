using Shop.Data.Models;
using Shop.Services.Mapping;
using System.Collections;
using System.Collections.Generic;

namespace Shop.Web.ViewModels.Brand
{
    public class BrandViewModel : IMapFrom<Shop.Data.Models.Brand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Logo { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
