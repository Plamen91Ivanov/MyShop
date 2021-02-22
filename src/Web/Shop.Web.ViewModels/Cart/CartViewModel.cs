using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Cart
{
    public class CartViewModel : IMapFrom<ProductCart>, IMapFrom<Shop.Data.Models.Cart>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<ProductCart> ProductCarts { get; set; }
    }
}
