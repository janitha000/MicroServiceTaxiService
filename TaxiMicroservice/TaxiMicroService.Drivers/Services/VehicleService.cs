using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;
using TaxiMicroService.Drivers.Entities.Resources;
using TaxiMicroService.Drivers.Repository.Interfaces;

namespace TaxiMicroService.Drivers.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IMapper mapper;

        public VehicleService(IVehicleRepository repo, IMapper _mapper)
        {
            vehicleRepository = repo ?? throw new ArgumentNullException(nameof(repo));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<Vehicle> AddVehicle(VehicleResource vehicleResource)
        {
            try
            {
                Vehicle vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
                await vehicleRepository.AddAsync(vehicle);

                return vehicle;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            List<Vehicle> vehicles = await vehicleRepository.GetAll();
            return vehicles;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            Vehicle vehicle = await vehicleRepository.GetSingle(id);
            return vehicle;
        }

        public async Task<Vehicle> GetVehicleAsync(Expression<Func<Vehicle, bool>> predicate)
        {
            Vehicle vehicle = await vehicleRepository.GetSingle(predicate);
            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicle(VehicleResource vehicleResource)
        {
            Vehicle vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            await vehicleRepository.Update(vehicle);
            return vehicle;
        }
    }
}
