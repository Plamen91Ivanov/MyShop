using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Create
{
    public class ProductInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public string Image { get; set; }
    }
}
