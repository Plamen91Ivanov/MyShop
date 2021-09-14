using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Services.Data;
using Shop.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class FriendRequestController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRequestService requestService;

        public FriendRequestController(UserManager<ApplicationUser> userManager, IRequestService requestService)
        {
            this.userManager = userManager;
            this.requestService = requestService;
        }

        public async Task<IActionResult> FriendRequest()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var users = new ProfilesFriendRequest
            {
                ProfileFriendRequests = this.requestService.FriendFromRequest<ProfileFriendRequest>(user.Id),
            };

            return this.View(users);
        }
    }
}
