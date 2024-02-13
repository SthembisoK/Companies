using AddBusSchedule.Models;

namespace AddBusSchedule.Interfaces
{
    public interface IScheduleService
    {
        Task CreateSchedule(Schedule schedule); 
      
    }
}
