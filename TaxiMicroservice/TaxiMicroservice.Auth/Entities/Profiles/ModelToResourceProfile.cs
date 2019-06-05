using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiMicroservice.Auth.Entities.Resources;

namespace TaxiMicroservice.Auth.Entities.Profiles
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, RegisterResource>();
            CreateMap<User, SiginResource>();
        }


    }
}
