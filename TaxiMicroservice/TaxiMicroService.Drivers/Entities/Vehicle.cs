﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroService.Drivers.Entities
{
    public class Vehicle : IEntityBase
    {
        [Key]

        public int Id { get; set; }
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
