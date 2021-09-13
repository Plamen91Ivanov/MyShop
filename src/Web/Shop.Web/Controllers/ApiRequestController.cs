using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Message;
using Shop.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRequestService requestService;

        public ApiRequestController(UserManager<ApplicationUser> userManager,
                                 IRequestService requestService)
        {
            this.userManager = userManager;
            this.requestService = requestService;
        }

        [HttpPost]
        [IgnoreAntiforgeryTokenAttribute]
        public async Task<ActionResult> Add(FriendRequest friendRequest)
        {
            var getUser = await this.userManager.GetUserAsync(this.User);
            var request = await this.requestService.SendFriendRequest(getUser.Id, friendRequest.UserToId);
            return this.Ok();
        }
    }
}
