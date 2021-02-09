using Shop.Data.Common.Models;
using System.Collections;
using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Images = new HashSet<ImageProduct>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public virtual ICollection<ImageProduct> Images { get; set; }
    }
}
