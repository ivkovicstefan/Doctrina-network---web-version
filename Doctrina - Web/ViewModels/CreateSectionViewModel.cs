using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class CreateSectionViewModel
    {
        [Required]
        public string Name { get; set; }
        public string GroupId { get; set; }
    }
}
