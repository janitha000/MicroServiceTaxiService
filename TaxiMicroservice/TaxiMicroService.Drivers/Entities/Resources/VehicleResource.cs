using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroService.Drivers.Entities.Resources
{
    public class VehicleResource
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public VehicleTypes VehicleType { get; set; }
    }
}
