using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;

namespace TaxiMicroService.Drivers.Services
{
    public interface IDriverService
    {
        Task<Driver> GetDriver(int id);
        Task<Driver> GetDriverAsync(Expression<Func<Driver, bool>> predicate);
        Task<List<Driver>> GetAllDrivers();
        Task<Driver> AddDriver(DriverResource driver);
    }
}
