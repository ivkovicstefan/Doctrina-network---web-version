using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class HomeViewModel
    {
        public IList<DoctrinaGroup> Groups { get; set; }
        public string Query { get; set; }
        public IList<DoctrinaUser> Results { get; set; }

    }
}
