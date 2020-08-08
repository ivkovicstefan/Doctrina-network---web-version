using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DoctrinaGroupSection> DoctrinaSections { get; set; }
        /// <summary>
        /// Navigation property for many-to-many relationship users-groups
        /// </summary>
        public virtual ICollection<DoctrinaUserDoctrinaGroup> DoctrinaUserDoctrinaGroups { get; set; }

    }
}
