using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using Shop.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
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
                UserId = userFromId,
                UserToId = userToId,
                Text = text,
            };

            await this.messages.AddAsync(messageText);
            await this.messages.SaveChangesAsync();
            return 1;
        }

        public IEnumerable<T> GetMessageById<T>(string userId)
        {
            var userMassage = this.messages.All().Where(x => x.UserToId == userId).To<T>().ToList();
            return userMassage;
        }
    }
}
