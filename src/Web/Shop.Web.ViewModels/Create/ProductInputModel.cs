using Shop.Data.Models;
using Shop.Services.Mapping;
using Shop.Web.ViewModels.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Create
{
    public class ProductInputModel : IMapFrom<Product>, IMapFrom<ImageProduct>, IMapFrom<ProductCart>, IMapFrom<Shop.Data.Models.Cart>
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int IntegerPrice => (int)this.Price;

        public int Coins => (int)this.Price;

        public string Location { get; set; }

        public string UserUserName { get; set; }

        public string Image { get; set; }

        public int SeenCount { get; set; }

        public string Url => $"f/{this.Name}";

        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
