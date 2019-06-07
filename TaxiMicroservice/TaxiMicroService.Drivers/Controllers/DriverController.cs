using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TaxiMicroService.Drivers.Entities;
using TaxiMicroService.Drivers.Extensions;
using TaxiMicroService.Drivers.Services;

namespace TaxiMicroService.Drivers.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;
        private readonly DevelopmentVariables developmentVariables;


        public DriverController(IDriverService _service, IOptions<DevelopmentVariables> _developmentVariables)
        {
            driverService = _service ?? throw new ArgumentNullException(nameof(_service));
            developmentVariables = _developmentVariables.Value ?? throw new ArgumentNullException(nameof(_developmentVariables.Value));


        }

        [HttpGet]
        public async Task<ActionResult> GetAllDrivers()
        {
            try
            {
                List<Driver> drivers = await driverService.GetAllDrivers();
                return Ok(drivers);
            }
            catch(Exception ex)
            {
                return Ok($"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDriver(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("Id is null");

                Driver driver = await driverService.GetDriver(Int32.Parse(id));
                return Ok(driver);
            }
            catch(Exception ex)
            {
                return Ok($"Internel server error: {ex.Message} ");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddDriver([FromBody] DriverResource resource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                Driver driver = await driverService.AddDriver(resource);
                string url = string.Format($"{developmentVariables.Url}/api/driver/{driver.Id}");
                return Created(url, driver);

            }
            catch(Exception ex)
            {
                return Ok($"Server error {ex.Message}");
            }

        }
    }
}