using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    /// <summary>
    /// Many-to-Many relationship between users which represents friendship.
    /// Table is directed (for each friendship there are two records in table)
    /// </summary>
    public class Friendship
    {
        public string UserId { get; set; }
        public DoctrinaUser User { get; set; }
        public string FriendId { get; set; }
        public DoctrinaUser Friend { get; set; }
        /// <summary>
        /// If user sent an invite to friend (->), but friend has not accepted yet
        /// </summary>
        public bool IsRequestPending { get; set; }
        /// <summary>
        /// If user got an invite from friend (<-), but he has not accepted yet.
        /// </summary>
        public bool IsInvitationPending { get; set; }
    }
}
