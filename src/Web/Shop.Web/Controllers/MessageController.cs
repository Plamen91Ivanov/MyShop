using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Message;
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

        [HttpPost]
        [IgnoreAntiforgeryTokenAttribute]
        public async Task<ActionResult> Add(MessageInputModel message)
        {
            var userId = await this.userManager.GetUserAsync(this.User);
            var messageText = await this.messageService.AddMessage("b", "b", "b");
            return this.Ok();
        }
    }
}
