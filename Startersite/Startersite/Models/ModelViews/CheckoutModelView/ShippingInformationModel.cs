using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class ShippingInformationModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Enter surname")]
        public string Surname { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Enter valid E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Phone numbet")]
        [Required(ErrorMessage ="Enter valid telephone number")]
        [DataType(DataType.PhoneNumber)]
        public double PhoneNumber { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Enter country")]
        public string Country { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter address")]
        public string Address { get; set; }

        [Display(Name = "Address")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter city")]
        public string City { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Enter valid zip code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
    }
}