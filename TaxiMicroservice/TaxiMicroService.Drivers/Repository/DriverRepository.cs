using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;
using TaxiMicroService.Drivers.Repository.Interfaces;

namespace TaxiMicroService.Drivers.Repository
{
    public class DriverRepository : RepositoryBase<Driver> ,  IDriverRepository
    {
        public DriverRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
