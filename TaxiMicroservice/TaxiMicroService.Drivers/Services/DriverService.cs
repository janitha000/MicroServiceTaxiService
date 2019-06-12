using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;
using TaxiMicroService.Drivers.Repository.Interfaces;

namespace TaxiMicroService.Drivers.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository driverRepository;
        private readonly IMapper mapper;

        public DriverService(IDriverRepository repo, IMapper _mapper)
        {
            driverRepository = repo ?? throw new ArgumentNullException(nameof(repo));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<Driver> AddDriver(DriverResource driverResource)
        {
            Driver driver = mapper.Map<DriverResource, Driver>(driverResource);
            await driverRepository.AddAsync(driver);

            return driver;
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            List<Driver> drivers = await driverRepository.GetAll();
            return drivers;

        }

        public async Task<Driver> GetDriver(int id)
        {
            Driver driver = await driverRepository.GetSingle(id);
            return driver;
        }

        public async Task<Driver> GetDriverAsync(Expression<Func<Driver, bool>> predicate)
        {
            Driver driver = await driverRepository.GetSingle(predicate);
            return driver;
        }

        public async Task<Driver> UpdateDriver(DriverResource driverResource)
        {
            Driver driver = mapper.Map<DriverResource, Driver>(driverResource);
            await driverRepository.Update(driver);
            return driver;
        }
    }
}
