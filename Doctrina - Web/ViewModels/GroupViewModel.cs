using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class GroupViewModel
    {
        public string GroupName { get; set; }
        public IList<DoctrinaUser> Members { get; set; }
    }
}
