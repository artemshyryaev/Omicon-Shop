using System;
using System.ComponentModel.DataAnnotations;

namespace OmiconShop.Domain.Entities
{
    public class UserPersonalInformation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        //public string Email { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
    }
}