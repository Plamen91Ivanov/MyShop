using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class MessageController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessageService messageService;

        public MessageController(UserManager<ApplicationUser> userManager,
                                 IMessageService messageService)
        {
            this.userManager = userManager;
            this.messageService = messageService;
        }

        [Route("message/{test}/")]
        [HttpGet]
        public async Task<ActionResult> Add(string userFromId, string userToId, string test)
        {
            var userId = await this.userManager.GetUserAsync(this.User);
            var messageText = await this.messageService.AddMessage(userFromId, userToId, test);
            return this.Ok();
        }
    }
}
