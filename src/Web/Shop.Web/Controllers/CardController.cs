using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public CardController(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Add(int id)
        {
            var userId = await this.userManager.GetUserAsync(this.User);

            CardVendor product = new CardVendor
            {
                ProductId = id,
                UserId = userId.Id,
            };

            await this.context.CardVendors.AddAsync(product);
            await this.context.SaveChangesAsync();

            return this.Ok();
        }
    }
}
