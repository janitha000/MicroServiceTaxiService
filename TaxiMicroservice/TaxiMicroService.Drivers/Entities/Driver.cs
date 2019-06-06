using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroService.Drivers.Entities
{
    public class Driver : IEntityBase
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public int Age { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
