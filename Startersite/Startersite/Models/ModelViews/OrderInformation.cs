﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite
{
    public class OrderInformation
    {
        [Key]
        public int Id { get; set; }

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

        [Display(Name="Phone number")]
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

        [Display(Name = "Delivery method")]
        public MethodsOfDelivery Delivery { get; set; }

        [Display(Name = "Payment method")]
        public MethodOfPayment Payment { get; set; }

        ICollection<Order> Orders { get; set; }

        public OrderInformation()
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