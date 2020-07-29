using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.Models
{
    public class DoctrinaScript
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
        public DoctrinaUser Creator { get; set; }
        public DoctrinaUser LastModifiedBy { get; set; }
        /// <summary>
        /// Path to the actual script file created on server (.html file)
        /// </summary>
        public string FilePath { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public DoctrinaGroupSection DoctrinaGroupSection { get; set; }
    }
}
