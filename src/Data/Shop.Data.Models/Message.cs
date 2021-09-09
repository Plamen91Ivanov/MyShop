using Shop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Models
{
    public class Message : BaseDeletableModel<int>
    {
        public string UserFromId { get; set; }

        public string UserToId { get; set; }

        public string Text { get; set; }
    }
}
