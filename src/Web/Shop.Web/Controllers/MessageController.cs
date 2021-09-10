using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMessageService messageService;
        private readonly UserManager<ApplicationUser> userManager;

        public MessageController(IMessageService messageService,
                                 UserManager<ApplicationUser> userManager) {

            this.messageService = messageService;
            this.userManager = userManager;
        }

        public async Task<ActionResult> Message()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var text = new Messages();
            text.Text = this.messageService.GetMessageById<MessageInputModel>(user.Id);
            return this.View(text);
        }
    }
}
