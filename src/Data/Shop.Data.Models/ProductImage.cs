using Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class ProductImage : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
    }
}
