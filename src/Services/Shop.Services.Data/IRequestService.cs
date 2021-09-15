using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface IRequestService
    {
        Task<int> SendFriendRequest(string userId, string requestedUser);

        Task<int> AcceptFriendRequest(string userId, string userFromId);

        IEnumerable<T> FriendFromRequest<T>(string userId);
    }
}
