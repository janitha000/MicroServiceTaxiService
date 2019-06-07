using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroService.Drivers.Entities
{
    public class DriverResource
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NIC { get; set; }
        [Required]
        public int Age { get; set; }
        public string VehicleId { get; set; }
    }
}
