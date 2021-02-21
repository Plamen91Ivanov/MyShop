using Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class Cart : BaseDeletableModel<int>
    {
        public Cart()
        {
            this.ProductCarts = new HashSet<ProductCart>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<ProductCart> ProductCarts { get; set; }
    }
}
