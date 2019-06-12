using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;
using TaxiMicroService.Drivers.Entities.Resources;

namespace TaxiMicroService.Drivers.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> GetVehicle(int id);
        Task<Vehicle> GetVehicleAsync(Expression<Func<Vehicle, bool>> predicate);
        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle> AddVehicle(VehicleResource driver);
        Task<Vehicle> UpdateVehicle(VehicleResource driver);
    }
}
