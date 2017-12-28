using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentCars.Models
{
    [Table("CarRentals")]
    public class CarRentalModel
    {
        [Key]
        public int CarRentalId { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        [ForeignKey("Cars")]
        public int CarId { get; set; }

        public decimal CarRentalRate { get; set; }

        public virtual CarModel Cars { get; set; }

        public virtual CustomerModel Customers { get; set; }
    }
}