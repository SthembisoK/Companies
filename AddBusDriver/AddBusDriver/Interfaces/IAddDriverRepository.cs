using AddBusDriver.Models;

namespace AddBusDriver.Interfaces
{
    public interface IAddDriverRepository
    {
        Task CreateAddDriver(AddDriver addDriver);
    }
}
