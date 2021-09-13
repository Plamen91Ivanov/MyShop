using Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class Relationship : BaseDeletableModel<int>
    {
        public string UserFirstId { get; set; }

        public string UserSecondId { get; set; }

        public int Type { get; set; }
    }
}
