using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentCars.Models
{
    [Table("Cars")]
    public class CarModel
    {
        [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Colour { get; set; }

        public virtual ICollection<CarRentalModel> CarRentals { get; set; }
    }
}