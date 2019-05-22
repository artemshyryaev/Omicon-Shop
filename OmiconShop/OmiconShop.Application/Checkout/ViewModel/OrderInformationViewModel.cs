using OmiconShop.Application.Resources;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmiconShop.Application.Checkout.ViewModel
{
    public class OrderInformationViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "NameValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        public string Name { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "SurnameValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        public string Surname { get; set; }

        [Display(Name = "Email", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "EmailValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "PhoneNumberValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "CountryValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        public string Country { get; set; }

        [Display(Name = "City", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "CityValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.MultilineText)]
        public string City { get; set; }

        [Display(Name = "Address", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "AddressValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Address2", ResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.MultilineText)]
        public string Address2 { get; set; }

        [Display(Name = "ZipCode", ResourceType = typeof(OrderInformationResources))]
        [Required(ErrorMessageResourceName = "ZipCodeValidation",
            ErrorMessageResourceType = typeof(OrderInformationResources))]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "Delivery", ResourceType = typeof(OrderInformationResources))]
        [UIHint("EnumDropDown")]
        public ShippingMethods Delivery { get; set; }

        [Display(Name = "Payment", ResourceType = typeof(OrderInformationResources))]
        [UIHint("EnumDropDown")]
        public PaymentMethods Payment { get; set; }

        ICollection<Order> Orders { get; set; }

        public OrderInformationViewModel()
        {
            Orders = new List<Order>();
        }
    }
}