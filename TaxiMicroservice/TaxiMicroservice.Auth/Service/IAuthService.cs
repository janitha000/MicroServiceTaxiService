using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiMicroservice.Auth.Entities;

namespace TaxiMicroservice.Auth.Service
{
    public interface IAuthService
    {
        Task<ApiResult> RegisterAsync(User user);
        Task<ApiResult> LoginAsync(User user);
    }
}
