using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaUserRepository : IDoctrinaUserRepository
    {
        private readonly DoctrinaDBContext _db;

        public DoctrinaUserRepository(DoctrinaDBContext db)
        {
            _db = db;
        }
        public IEnumerable<DoctrinaUser> SearchUsers(string searchText)
        {
            var result = _db.Users.Where(u => u.UserName.Contains(searchText));
            return result;
        }

        public void SendFriendRequest(DoctrinaUser user, DoctrinaUser friend)
        {
            Friendship userToFriend = new Friendship
            {
                UserId = user.Id,
                FriendId = friend.Id,
                IsInvitationPending = false,
                IsRequestPending = true
            };

            Friendship friendToUser = new Friendship
            {
                UserId = friend.Id,
                FriendId = user.Id,
                IsInvitationPending = true,
                IsRequestPending = false
            };

            _db.Add<Friendship>(userToFriend);
            _db.Add<Friendship>(friendToUser);
            _db.SaveChanges();
        }

        public void AcceptFriendRequest(DoctrinaUser user, DoctrinaUser friend)
        {
            Friendship userToFriend = _db.Find<Friendship>(user.Id, friend.Id);
            Friendship friendToUser = _db.Find<Friendship>(friend.Id, user.Id);

            userToFriend.IsInvitationPending = false;
            friendToUser.IsRequestPending = false;

            _db.Update<Friendship>(userToFriend);
            _db.Update<Friendship>(friendToUser);
            _db.SaveChanges();

        }

        public Friendship GetFriendshipInformation(DoctrinaUser user, DoctrinaUser friend)
        {
            Friendship result = _db.Find<Friendship>(user.Id, friend.Id);
            return result;
        }

        public IList<string> GetFriendIds(DoctrinaUser user)
        {
            IList<Friendship> friendships = _db.Friendships.Where(u => u.UserId == user.Id).ToList();
            IList<string> result = new List<string>();

            foreach(var friendship in friendships)
            {
                result.Add(friendship.FriendId);
            }

            return result;
        }

        public void DeleteFriendship(DoctrinaUser user, DoctrinaUser friend)
        {
            Friendship userToFriend = _db.Find<Friendship>(user.Id, friend.Id);
            Friendship friendToUser = _db.Find<Friendship>(friend.Id, user.Id);

            _db.Remove<Friendship>(userToFriend);
            _db.Remove<Friendship>(friendToUser);
            _db.SaveChanges();
        }
    }
}
