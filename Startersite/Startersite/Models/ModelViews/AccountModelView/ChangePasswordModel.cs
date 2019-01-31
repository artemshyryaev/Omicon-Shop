using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The minimum length must be 3 digits!")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The minimum length must be 3 digits!")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The passwords do no match!")]
        public string ConfirmNewPassword { get; set; }
    }
}