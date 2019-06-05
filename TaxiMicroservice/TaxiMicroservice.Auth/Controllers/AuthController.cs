using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiMicroservice.Auth.Entities;
using TaxiMicroservice.Auth.Extensions;
using TaxiMicroservice.Auth.Service;

namespace TaxiMicroservice.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;

        public AuthController(IAuthService service)
        {
            authService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                ApiResult result = await authService.RegisterAsync(user);
                if (result.Status)
                    return Ok("User registration success");
                else
                    return BadRequest(result.Message);
            }
            catch(Exception ex)
            {
                return Ok(new ApiResult(false, ex));
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                ApiResult result = await authService.LoginAsync(user);
                if (result.Status)
                    return Ok("User login success");
                else
                    return BadRequest(result.Message);

            }
            catch(Exception ex)
            {
                return Ok(new ApiResult(false, ex));
            }
        }
    }
}