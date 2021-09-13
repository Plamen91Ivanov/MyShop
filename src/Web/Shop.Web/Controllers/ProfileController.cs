using Microsoft.AspNetCore.Mvc;
using Shop.Services.Data;
using Shop.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService profile;

        public ProfileController(IProfileService profile)
        {
            this.profile = profile;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> ProfileByName(string name)
        {
            var profile = this.profile.GetByName<ProfileViewModel>(name);
            return this.View(profile);
        }
    }
}
