using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public IActionResult categoryByName(string name)
        {

            return this.View();
        }
    }
}
