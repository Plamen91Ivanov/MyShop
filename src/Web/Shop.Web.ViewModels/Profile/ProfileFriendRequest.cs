using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Profile
{
    public class ProfileFriendRequest : IMapFrom<Relationship>, IMapFrom<ApplicationUser>
    {
        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public string UserName => $"{this.UserUserName.Split('@')[0]}";
    }
}
