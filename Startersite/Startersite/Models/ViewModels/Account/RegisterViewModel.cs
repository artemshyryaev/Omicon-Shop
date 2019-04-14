using Startersite.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login", ResourceType =typeof(LoginResources))]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Password", ResourceType = typeof(LoginResources))]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "LengthValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(LoginResources))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "PasswordComparisonValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(LoginResources))]
        public bool RememberMe { get; set; }
    }
}