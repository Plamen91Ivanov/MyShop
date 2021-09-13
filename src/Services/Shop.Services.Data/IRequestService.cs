using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface IRequestService
    {
        Task<int> SendFriendRequest(string userId, string requestedUser);
    }
}
