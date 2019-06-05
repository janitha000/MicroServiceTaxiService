using AutoMapper;
using TaxiMicroservice.Auth.Entities.Resources;

namespace TaxiMicroservice.Auth.Entities.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegisterResource, User>();
            CreateMap<SiginResource, User>();
        }
    }
}
