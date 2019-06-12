using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public AuthController(IAuthService service, IMapper _mapper, ILogger<AuthController> _logger)
        {
            authService = service ?? throw new ArgumentNullException(nameof(service));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource register)
        {
            logger.LogDebug($"Register endpoint called {register.Name} , {register.Email}");
            try
            {
                if (!ModelState.IsValid)
                {
                    logger.LogDebug($"Bad request {ModelState.GetErrorMessages()}");
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
            logger.LogDebug($"Register endpoint called {sigin.Name} , {sigin.Password}");
            try
            {
                if (!ModelState.IsValid)
                {
                    logger.LogDebug($"Bad request {ModelState.GetErrorMessages()}");
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