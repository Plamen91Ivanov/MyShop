using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public interface IMessageService
    {
        Task<int> AddMessage(string userFromId, string userToId, string text);
    }
}
