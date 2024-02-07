using AddBusDriver.Interfaces;
using AddBusDriver.Models;
using Google.Api.Gax;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddBusDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDriverController : ControllerBase
    {
        private readonly IAddDriverService _addDriverService;
        public AddDriverController(IAddDriverService addDriverService)
        {
            _addDriverService = addDriverService;
        }
        [HttpPost]

        public async Task<IActionResult>AddDrivers(AddDriver addDriver)
        {
            try
            {
                await _addDriverService.CreateAddDriver(addDriver);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}

