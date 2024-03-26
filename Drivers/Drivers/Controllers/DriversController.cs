using Dapper;
using Drivers.Interface;
using Drivers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverRepository _driverRepo;
        public DriversController(IDriverRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }

        [HttpPost]
        public async Task<ActionResult<List<ManageDrivers>>> GetDrivers(ManageDrivers driver)
        {
            var createdDriver = await _driverRepo.AddDrivers(driver);

            // Return the created schedule along with a success message
            return Ok(new { message = "Driver successfully added", driver = createdDriver });
        }

        [HttpGet]

        public async Task<IActionResult> GetDrivers()
        {
            try
            {
                var drivers = await _driverRepo.GetDrivers();
                return Ok(drivers);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var driver = await _driverRepo.GetDriver(id);
            if (driver == null)
                return NotFound();

            return Ok(driver);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] ManageDrivers driver)
        {
            var dbDriver = await _driverRepo.GetDriver(id);
            if (dbDriver == null)
                return NotFound();

            await _driverRepo.UpdateDriver(id, driver);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDriver(int id)
        {
            var dbDriver = await _driverRepo.GetDriver(id);
            if (dbDriver == null)
                return NotFound();

            await _driverRepo.DeleteDriver(id);
            return NoContent();
        }

    }
}
