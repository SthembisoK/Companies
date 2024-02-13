using AddBusSchedule.Models;

namespace AddBusSchedule.Interfaces
{
    public interface IScheduleRepository
    {
        Task CreateSchedule(Schedule schedule);

    }
}
