using Doctrina___Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class CreateScriptViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string FilePath { get; set; }
        public DoctrinaUser Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public string GroupId { get; set; }
        public int SectionId { get; set; }
    }
}
