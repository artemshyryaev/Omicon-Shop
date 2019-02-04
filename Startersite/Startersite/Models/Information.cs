using System.ComponentModel.DataAnnotations;

namespace Startersite
{
    public class Information
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public double PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public MethodsOfDelivery Delivery { get; set; }

        public MethodOfPayment Payment { get; set; }
    }
}