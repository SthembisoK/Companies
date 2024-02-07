using AddBusDriver.Models;

namespace AddBusDriver.Interfaces
{
    public interface IAddDriverService
    {
        Task CreateAddDriver(AddDriver addDriver);
    }
}
