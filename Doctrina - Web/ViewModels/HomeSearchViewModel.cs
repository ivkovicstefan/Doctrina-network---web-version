using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class HomeSearchViewModel
    {
        public IEnumerable<DoctrinaUser> Results { get; set; }
        public string Query { get; set; }
    }
}
