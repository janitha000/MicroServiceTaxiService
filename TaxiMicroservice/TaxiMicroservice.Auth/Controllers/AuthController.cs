using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiMicroservice.Auth.Entities;
using TaxiMicroservice.Auth.Entities.Resources;
using TaxiMicroservice.Auth.Extensions;
using TaxiMicroservice.Auth.Service;

namespace TaxiMicroservice.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;
        private readonly IMapper mapper;

        public AuthController(IAuthService service, IMapper _mapper)
        {
            authService = service ?? throw new ArgumentNullException(nameof(service));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource register)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                User user = mapper.Map<RegisterResource, User>(register);

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
        public async Task<IActionResult> Login([FromBody] SiginResource sigin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                User user = mapper.Map<SiginResource, User>(sigin);

                ApiResult result = await authService.LoginAsync(user);

                if (result.Status)
                    return Ok(result.Message);
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