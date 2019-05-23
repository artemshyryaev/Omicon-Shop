using OmiconShop.Application.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.Account.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "Login", ResourceType = typeof(LoginResources))]
        [Required(ErrorMessageResourceName = "LoginValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string Login { get; set; }

        [Display(Name = "Name", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "NameValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        public string Name { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "SurnameValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        public string Surname { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "PhoneNumberValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "CountryValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        public string Country { get; set; }

        [Display(Name = "Address", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "AddressValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Address2", ResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }

        [Display(Name = "City", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "CityValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.MultilineText)]
        public string City { get; set; }

        [Display(Name = "ZipCode", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "ZipCodeValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Required(ErrorMessageResourceName = "PasswordValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        [Display(Name = "Password", ResourceType = typeof(LoginResources))]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "LengthValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "ConfirmPasswordValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(LoginResources))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceName = "PasswordComparisonValidation",
            ErrorMessageResourceType = typeof(LoginResources))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(LoginResources))]
        public bool RememberMe { get; set; }
    }
}