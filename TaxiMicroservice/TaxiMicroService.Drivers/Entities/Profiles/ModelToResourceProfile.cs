using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities.Resources;

namespace TaxiMicroService.Drivers.Entities.Profiles
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Driver, DriverResource>();
            CreateMap<Vehicle, VehicleResource>();
        }
    }
}
