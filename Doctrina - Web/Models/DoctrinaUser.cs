using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public virtual ICollection<DoctrinaUserDoctrinaSchool> DoctrinaUserDoctrinaSchools { get; set; }
        /// <summary>
        /// Navigation property for many-to-many relationship users-groups
        /// </summary>
        public virtual ICollection<DoctrinaUserDoctrinaGroup> DoctrinaUserDoctrinaGroups { get; set; }
        /// <summary>
        /// Navigation property for many-to-many relationship users-users (friend)
        /// </summary>
        public virtual ICollection<Friendship> Friend { get; set; }
        /// <summary>
        /// Navigation property for many-to-many relationship users-users (friend of)
        /// </summary>
        public virtual ICollection<Friendship> FriendOf { get; set; }
        /// <summary>
        /// Absolute path to a profile image
        /// </summary>
        public string PhotoPath { get; set; }
    }
}
