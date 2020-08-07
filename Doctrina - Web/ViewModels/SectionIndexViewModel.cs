using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class SectionIndexViewModel : GroupViewModel
    {
        public DoctrinaGroupSection CurrentSection { get; set; }

        public IList<DoctrinaScript> Scripts { get; set; }

        public SectionSettingsViewModel SectionSettings { get; set; }

        public CreateScriptViewModel CreatedScript { get; set; }

    }

    public class SectionSettingsViewModel
    {
        [Display(Name="New section name:")]
        public string NewName { get; set; }
    }
}
