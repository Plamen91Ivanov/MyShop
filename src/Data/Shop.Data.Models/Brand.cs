using Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class Brand : BaseDeletableModel<int>
    {

        public Brand()
        {
            this.Products = new HashSet<Product>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Logo { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
