using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.Services.Data;
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
        private readonly ICardService cardService;

        public CardController(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              ICardService cardService)
        {
            this.context = context;
            this.userManager = userManager;
            this.cardService = cardService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Add(int id)
        {
            var userId = await this.userManager.GetUserAsync(this.User);

            var productId = await this.cardService.AddProductToCart(id, userId.Id);

            return this.Ok();
        }
    }
}
