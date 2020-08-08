using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    /// <summary>
    /// Many-To-Many relationship between users and groups
    /// </summary>
    public class DoctrinaUserDoctrinaGroup
    {
        public string DoctrinaUserId { get; set; }
        public virtual DoctrinaUser DoctrinaUser { get; set; }
        public string DoctrinaGroupId { get; set; }
        public virtual DoctrinaGroup DoctrinaGroup { get; set; }
        /// <summary>
        /// Checking if user is also an administrator
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// If group sent an invite to an user, but invite is not accepted yet
        /// </summary>
        public bool IsInvitePending { get; set; }
        /// <summary>
        /// If user requested to join, but administrators did not accept the request yet
        /// </summary>
        public bool IsRequestPending { get; set; }
    }
}
