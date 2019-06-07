using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TaxiMicroService.Drivers.Entities;

namespace TaxiMicroService.Drivers.Repository.DataGenerators
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.Vehicles.Any())
                {
                    return;
                }

                context.Vehicles.AddRange(
                    new Vehicle { Id = 1, Number = "7464", VehicleType = VehicleTypes.Car },
                    new Vehicle { Id = 2, Number = "2323", VehicleType = VehicleTypes.Van },
                    new Vehicle { Id = 3, Number = "2343", VehicleType = VehicleTypes.Car },
                    new Vehicle { Id = 4, Number = "4563", VehicleType = VehicleTypes.Car },
                    new Vehicle { Id = 5, Number = "9043", VehicleType = VehicleTypes.Bus },
                    new Vehicle { Id = 6, Number = "7474", VehicleType = VehicleTypes.ThreeWheel }
                    );

                if (context.Drivers.Any())
                {
                    return;
                }

                context.Drivers.AddRange(
                    new Driver { Id = 1, FirstName = "Janitha", LastName = "Tennakoon", Age = 29, NIC = "909090", VehicleId = "1" },
                    new Driver { Id = 2, FirstName = "Vindya", LastName = "Hettige", Age = 29, NIC = "323232", VehicleId = "4" },
                    new Driver { Id = 3, FirstName = "Prageesha", LastName = "Tennakoon", Age = 29, NIC = "232323", VehicleId = "3" },
                    new Driver { Id = 4, FirstName = "Shanika", LastName = "Tennakoon", Age = 29, NIC = "3232324", VehicleId = "5" }

                    );

                context.SaveChanges();
            }
        }
    }
}
