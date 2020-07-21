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
        /// <summary>
        /// Navigation property for many-to-many relationship users-groups
        /// </summary>
        public ICollection<DoctrinaUserDoctrinaGroup> DoctrinaUserDoctrinaGroups { get; set; }
    }
}
