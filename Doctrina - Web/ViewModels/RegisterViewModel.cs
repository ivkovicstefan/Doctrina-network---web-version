using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrina___Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="First name:")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name="Last name:")]
        public string LastName { get; set; }
        [Required]
        [Display(Name="Username:")]
        [Remote(action: "IsUserNameTaken", controller: "Account")]
        public string UserName { get; set; }
        [Required]
        [Display(Name="Email:")]
        [Remote(action: "IsEmailTaken", controller: "Account")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm password:")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
