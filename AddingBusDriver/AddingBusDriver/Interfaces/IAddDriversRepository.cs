using AddingBusDriver.Models;

namespace AddingBusDriver.Interfaces
{
    public interface IAddDriversRepository
    {
        public Task<Driver> GetDrivers(Driver driver);
    }
}
