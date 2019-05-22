using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmiconShop.Application.Resources;

namespace OmiconShop.Application.Admin.ViewModel
{
    public class UserViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Email", ResourceType = typeof(UserResources))]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceName = "EmailValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        public string Email { get; set; }

        [Display(Name = "Name", ResourceType = typeof(UserResources))]        
        [Required(ErrorMessageResourceName = "NameValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(UserResources))]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceName = "EmailValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        public string Surname { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(UserResources))]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessageResourceName = "PhoneNumberValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country", ResourceType = typeof(UserResources))]
        [Required(ErrorMessageResourceName = "CountryValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        public string Country { get; set; }

        [Display(Name = "Address", ResourceType = typeof(UserResources))]
        [Required(ErrorMessageResourceName = "AddressValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Address2", ResourceType = typeof(UserResources))]
        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }

        [Display(Name = "City", ResourceType = typeof(UserResources))]
        [Required(ErrorMessageResourceName = "CityValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        [DataType(DataType.MultilineText)]
        public string City { get; set; }

        [Display(Name = "ZipCode", ResourceType = typeof(UserResources))]
        [Required(ErrorMessageResourceName = "ZipCodeValidation",
            ErrorMessageResourceType = typeof(UserResources))]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
    }
}
