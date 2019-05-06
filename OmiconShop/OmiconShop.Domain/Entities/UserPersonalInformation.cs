using System;
using System.ComponentModel.DataAnnotations;

namespace OmiconShop.Domain.Entities
{
    public class UserPersonalInformation
    {
        public int UserPersonalInformationId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}