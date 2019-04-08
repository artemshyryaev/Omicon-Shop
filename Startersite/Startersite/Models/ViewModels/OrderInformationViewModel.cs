using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Models.ViewModel
{
    public class OrderInformationViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter name.")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Enter surname.")]
        public string Surname { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Enter valid E-mail.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Enter valid telephone number.")]
        [DataType(DataType.PhoneNumber)]
        public double PhoneNumber { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Enter country.")]
        public string Country { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter address.")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Address2")]
        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter city.")]
        [DataType(DataType.MultilineText)]
        public string City { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Enter valid zip code.")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "Delivery method")]
        [UIHint("EnumDropDown")]
        public MethodsOfDelivery Delivery { get; set; }

        [Display(Name = "Payment method")]
        [UIHint("EnumDropDown")]
        public MethodOfPayment Payment { get; set; }

        ICollection<Order> Orders { get; set; }

        public OrderInformationViewModel()
        {
            Orders = new List<Order>();
        }
    }

    public enum MethodsOfDelivery
    {
        Fedex,

        NovaPoshta,

        Buckaroo,

        Post24,

        UaDelivery
    }

    public enum MethodOfPayment
    {
        Visa,

        Mastercard,

        PayPall,

        Dibs,

        Docdata,

        AfterPay,

        Klarna
    }
}