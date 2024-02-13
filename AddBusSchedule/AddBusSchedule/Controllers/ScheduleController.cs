using AddBusSchedule.Interfaces;
using AddBusSchedule.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddBusSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleservice;
        public ScheduleController(IScheduleService scheduleService) {
            _scheduleservice = scheduleService;      
        }

        [HttpPost]

        public async Task<IActionResult>AddSchedule(Schedule schedule) 
        {
            try
            {
                await _scheduleservice.CreateSchedule(schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        
        }

    }
   

}
