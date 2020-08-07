using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public interface IDoctrinaUserRepository
    {
        /// <summary>
        /// Searches and returns users by username
        /// </summary>
        /// <param name="searchText">Searching keyword, can be partial</param>
        /// <returns></returns>
        public IList<DoctrinaUser> SearchUsers(string searchText);
        /// <summary>
        /// Creates two records in Friendship table. Records are in both directions.
        /// </summary>
        /// <param name="user">User who sent friend request</param>
        /// <param name="friend">User who recieves the request</param>
        public void SendFriendRequest(DoctrinaUser user, DoctrinaUser friend);
        /// <summary>
        /// Sets 'IsInvitationPending' and 'IsRequestPending' values to 'false' in Friendship table.
        /// </summary>
        /// <param name="user">User who accepts the friend request</param>
        /// <param name="friend">User who sent the friend request</param>
        public void AcceptFriendRequest(DoctrinaUser user, DoctrinaUser friend);
        /// <summary>
        /// Returns collection of user's friend ids
        /// </summary>
        /// <returns></returns>
        public IList<string> GetFriendIds(DoctrinaUser user);
        /// <summary>
        /// Returns row from Friendship table
        /// </summary>
        /// <param name="user">Logged user</param>
        /// <param name="friend">Potential friend</param>
        /// <returns></returns>
        public Friendship GetFriendshipInformation(DoctrinaUser user, DoctrinaUser friend);
        /// <summary>
        /// Deletes friendship records from Friendship table in case of unfriending or declining friend requests
        /// </summary>
        /// <param name="user">Logged user</param>
        /// <param name="friend">Potential friend</param>
        public void DeleteFriendship(DoctrinaUser user, DoctrinaUser friend);
    }
}
