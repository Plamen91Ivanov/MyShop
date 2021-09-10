using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Message
{
    public class Messages : IMapFrom<Shop.Data.Models.Message>
    {
        public IEnumerable<MessageInputModel> Text { get; set; }
    }
}
