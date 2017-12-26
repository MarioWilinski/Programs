using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentCars.Models
{
    [Table("Customers")]
    public class CustomerModel
    {
        [Key]
        public int CustomerId {get; set;}
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Steet { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Coutry { get; set; }
        public virtual ICollection<CarRentalModel> CarRentals { get; set; }
    }
}