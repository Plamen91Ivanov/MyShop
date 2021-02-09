using Shop.Data.Models;
using Shop.Services.Mapping;
using Shop.Web.ViewModels.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Create
{
    public class ProductInputModel : IMapFrom<Product>, IMapFrom<ImageProduct>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public string UserUserName { get; set; }

        public string Url => $"{this.Name}";

        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
