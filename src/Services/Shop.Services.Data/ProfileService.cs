using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services.Data
{
    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> user;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> user)
        {
            this.user = user;
        }

        public T GetByName<T>(string name)
        {
            var profile = this.user.All().Where(x=> x.UserName.Contains(name)).To<T>().FirstOrDefault();
            return profile;
        }
    }
}
