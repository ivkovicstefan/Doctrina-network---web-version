using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class EditScriptViewModel
    {
        public DoctrinaScript ThisScript { get; set; }
        public string GroupId { get; set; }
        public int SectionId { get; set; }
    }
}
