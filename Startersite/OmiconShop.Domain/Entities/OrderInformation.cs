﻿using System;
using OmiconShop.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace OmiconShop.Domain.Entities
{
    public class OrderInformation
    {
        public int Id { get; set; }

        public double Total { get; set; }

        public DateTime Date { get; set; }        

        public ShippingMethods Delivery { get; set; }

        public PaymentMethods Payment { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}