using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaUserDoctrinaSchool
    {
        public string DoctrinaUserId { get; set; }
        public virtual DoctrinaUser DoctrinaUser { get; set; }
        public string DoctrinaSchoolId { get; set; }
        public virtual DoctrinaSchool DoctrinaSchool { get; set; }
    }
}
