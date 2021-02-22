using Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class CartProduct : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
