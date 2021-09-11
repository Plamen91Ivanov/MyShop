using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Message
{
    public class MessageInputModel : IMapFrom<Shop.Data.Models.Message>
    {
        public string Text { get; set; }

        public string UserToId { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }
    }
}
