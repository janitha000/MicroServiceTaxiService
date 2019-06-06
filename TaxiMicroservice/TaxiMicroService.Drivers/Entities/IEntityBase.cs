using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroService.Drivers.Entities
{
    public interface IEntityBase
    {
        string Id { get; set; }
    }
}
