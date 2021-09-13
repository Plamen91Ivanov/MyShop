using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Data
{
    public class RequestService : IRequestService
    {
        private readonly IDeletableEntityRepository<Relationship> relationship;

        public RequestService(IDeletableEntityRepository<Relationship> relationship)
        {
            this.relationship = relationship;
        }

        public async Task<int> SendFriendRequest(string userId, string requestedUser)
        {
            Relationship relationship = new Relationship
            {
                UserFirstId = userId,
                UserSecondId = requestedUser,
                Type = 1,
            };

            await this.relationship.AddAsync(relationship);
            await this.relationship.SaveChangesAsync();

            return 1;
        }
    }
}
