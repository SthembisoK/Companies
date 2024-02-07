using AddBusDriver.Interfaces;
using AddBusDriver.Models;
using Google.Api.Gax;

namespace AddBusDriver.Services
{

    public class AddDriverService : IAddDriverService
    {
        private readonly IAddDriverRepository _addDriverRepository;

        public AddDriverService(IAddDriverRepository addDriverRepository)
        {
            _addDriverRepository = addDriverRepository;
        }

        public async Task CreateAddDriver(AddDriver addDriver)
        {
            // Call the repository method to create the driver
            await _addDriverRepository.CreateAddDriver(addDriver);
        }
    }


    //public class AddDriverService : IAddDriverService
    //{
    //    private readonly IAddDriverRepository _addDriver;

    //    public AddDriverService(IAddDriverService addDriver)
    //    {
    //        _addDriver = addDriver;
    //    }
    //    public async Task CreateAddDriver(AddDriver addDriver)
    //    {
    //        await _addDriver.CreateAddDriver(addDriver);
    //    }
    //}
}
