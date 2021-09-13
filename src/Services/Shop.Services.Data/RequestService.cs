using Shop.Data.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int RequestCount(string userId)
        {
            var count = this.relationship.All().Where(x => x.UserSecondId == userId && x.Type == 1).Count();
            return count;
        }
    }
}
