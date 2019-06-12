using AutoMapper;
using TaxiMicroService.Drivers.Entities.Resources;

namespace TaxiMicroService.Drivers.Entities.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<DriverResource, Driver>();
            CreateMap<VehicleResource, Vehicle>();
        }
    }
}
