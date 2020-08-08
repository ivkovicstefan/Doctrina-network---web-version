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
        public virtual DoctrinaUser Creator { get; set; }
        public virtual DoctrinaUser LastModifiedBy { get; set; }
        /// <summary>
        /// Server-side path to the file (relative)
        /// </summary>
        public string WebRootPath { get; set; }
        /// <summary>
        /// Absolute (full) path to the file
        /// </summary>
        public string AbsolutePath { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }
        public virtual DoctrinaGroupSection DoctrinaGroupSection { get; set; }
    }
}
