﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace OmiconShop.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public int? UserPersonalInformationId { get; set; }

        public UserPersonalInformation UserPersonalInformation { get; set; }

        public int? UserAddressId { get; set; }

        public UserAddress UserAddress { get; set; }

        public ICollection<Order> Orders { get; private set; }

        public User()
        {
            Orders = new HashSet<Order>();
        }
    }
}