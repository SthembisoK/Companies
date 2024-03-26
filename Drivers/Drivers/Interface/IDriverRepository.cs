using Drivers.Models;

namespace Drivers.Interface
{
    public interface IDriverRepository
    {
        public Task<ManageDrivers> AddDrivers(ManageDrivers driver);
        public Task<IEnumerable<ManageDrivers>> GetDrivers();
        public Task<ManageDrivers> GetDriver(int id);
        public Task UpdateDriver(int id,ManageDrivers driver);
        public Task DeleteDriver(int id);

    }
}
