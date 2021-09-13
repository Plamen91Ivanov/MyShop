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
    public class ApiRequestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> user;
        private readonly IRequestService requestService;

        public ApiRequestController(UserManager<ApplicationUser> user,
                                    IRequestService requestService)
        {
            this.user = user;
            this.requestService = requestService;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> FriendRequest(string requestedUser)
        {
            var getUser = await this.user.GetUserAsync(this.User);
            var friendRequest = await this.requestService.SendFriendRequest(getUser.Id, requestedUser);
            return this.Ok();
        }
    }
}
