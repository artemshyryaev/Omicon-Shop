using OmiconShop.Application.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.Account.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter valid email.")]
        [Display(Name = "Email", ResourceType = typeof(LoginResources))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter valid password.")]
        [Display(Name = "Password", ResourceType = typeof(LoginResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(LoginResources))]
        public bool RememberMe { get; set; }
    }
}