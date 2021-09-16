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
                UserId = userId,
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

        public IEnumerable<T> FriendFromRequest<T>(string userId)
        {
            var users = this.relationship.All().Where(x => x.UserSecondId == userId && x.Type == 1).To<T>().ToList();
            return users;
        }

        public async Task<int> AcceptFriendRequest(string userId, string userFromId)
        {
            var accept = this.relationship.All().Where(x => x.UserId == userFromId && x.UserSecondId == userId).FirstOrDefault();
            accept.Type = 2;

            await this.relationship.SaveChangesAsync();
            return accept.Type;
        }



        //public IEnumerable<string> GetAllFriendRequests(string userId)
        //{
        //    var friendRequest = this.relationship.All().Where(x => x.UserSecondId == userId && x.Type == 1).ToList();
        //    return friendRequestl;
        //}
    }
}
