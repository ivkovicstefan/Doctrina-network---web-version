using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class GroupViewModel
    {
        public DoctrinaGroup Group { get; set; }
        public IList<DoctrinaUser> Members { get; set; }
        public IList<DoctrinaGroupSection> Sections { get; set; }
        public GroupSettingsViewModel Settings { get; set; }
    }

    public class GroupSettingsViewModel
    {
        [Display(Name="New group name:")]
        public string NewName { get; set; }
    }
}
