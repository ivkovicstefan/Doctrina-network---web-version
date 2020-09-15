using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="Username:")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
