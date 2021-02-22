using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class CartController : BaseController
    {
        public IActionResult Chekout()
        {
            return this.View();
        }

        public IActionResult Finish()
        {
            return this.View();
        }
    }
}
