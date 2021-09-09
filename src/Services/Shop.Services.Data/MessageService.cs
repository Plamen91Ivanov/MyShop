using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public class MessageService : IMessageService
    {
        private readonly IDeletableEntityRepository<Message> messages;

        public MessageService(IDeletableEntityRepository<Message> messages)
        {
            this.messages = messages;
        }

        public async Task<int> AddMessage(string userFromId, string userToId, string text)
        {
            Message messageText = new Message
            {
                UserFromId = userFromId,
                UserToId = userToId,
                Text = text,
            };

            await this.messages.AddAsync(messageText);
            await this.messages.SaveChangesAsync();
            return 1;
        }
    }
}
