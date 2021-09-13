using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class FriendRequestController : BaseController
    {
        public FriendRequestController()
        {

        }

        public IActionResult FriendRequest()
        {
            return this.View();
        }
    }
}
