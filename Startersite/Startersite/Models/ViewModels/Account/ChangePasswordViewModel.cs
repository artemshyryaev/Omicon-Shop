using Startersite.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite.Models.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "OldPassword", ResourceType = typeof(LoginResources))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName ="LengthValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(LoginResources))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceName = "LengthValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(LoginResources))]
        [Compare("NewPassword", ErrorMessageResourceName = "PasswordComparisonValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string ConfirmNewPassword { get; set; }
    }
}