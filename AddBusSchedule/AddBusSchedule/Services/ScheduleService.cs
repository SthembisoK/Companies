using AddBusSchedule.Interfaces;
using AddBusSchedule.Models;

namespace AddBusSchedule.ViewModels
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _schedule;
        public ScheduleService(IScheduleRepository schedule)
        {
            _schedule = schedule;
        }

        public async Task CreateSchedule(Schedule schedule)
        {
            await _schedule.CreateSchedule(schedule);
        }
    }
}
