using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaGroupSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DoctrinaGroup DoctrinaGroup { get; set; }

    }
}
