using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Web.ViewModels.Search
{
    public class SearchUserViewModel : IMapFrom<ApplicationUser>
    {
       public string UserName { get; set; }

       public string Url => $"{this.UserName.Split('@')[0]}";
    }
}
