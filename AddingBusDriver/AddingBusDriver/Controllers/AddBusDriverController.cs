using AddingBusDriver.Interfaces;
using AddingBusDriver.Models;
using AddingBusDriver.Repository;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AddingBusDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddBusDriverController : ControllerBase
    {
        private readonly IAddDriversRepository _driverRepo;
        public AddBusDriverController(IAddDriversRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }

        [HttpPost]
        public async Task<ActionResult<List<Driver>>> GetDrivers(Driver driver)
        {
            var createdDriver = await _driverRepo.GetDrivers(driver);

            // Return the created schedule along with a success message
            return Ok(new { message = "Driver successfully added", driver = createdDriver });
        }
    }
}
