using Shop.Data.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Images = new HashSet<ImageProduct>();
            this.ProductCarts = new HashSet<ProductCart>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public string Image { get; set; }

        public int? BrandId { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int SeenCount { get; set; }

        public virtual ICollection<ImageProduct> Images { get; set; }

        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
