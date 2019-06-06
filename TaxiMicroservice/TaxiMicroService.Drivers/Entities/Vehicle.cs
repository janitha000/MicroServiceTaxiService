using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroService.Drivers.Entities
{
    public class Vehicle : IEntityBase
    {
        public string Id { get; set; }
        public int VehicleId { get; set; }
        public string Number { get; set; }
        public VehicleTypes VehicleType { get; set; }
    }

    public enum VehicleTypes
    {
        Car,
        Van,
        ThreeWheel,
        Bus
    }
}
