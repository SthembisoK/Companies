using Dapper;
using Drivers.Interface;
using Drivers.Models;
using GetBusDriver.Context;
using System.Data;

namespace Drivers.Repository
{
    public class DriverRepository:IDriverRepository
    {
        private readonly DBContext _context;
        public DriverRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<ManageDrivers> AddDrivers(ManageDrivers driver)
        {
            var query = "INSERT INTO BusDrivers (Email, FirstName, LastName) VALUES (@Email, @FirstName, @LastName)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Email", driver.Email, DbType.String);
            parameters.Add("FirstName", driver.FirstName, DbType.String);
            parameters.Add("LastName", driver.LastName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdDriver = new ManageDrivers
                {
                    Id = id,
                    Email = driver.Email,
                    FirstName = driver.FirstName,
                    LastName = driver.LastName

                };
                return createdDriver;
            }
        }

        public async Task DeleteDriver(int id)
        {
            var query = "DELETE FROM BusDrivers WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<ManageDrivers> GetDriver(int id)
        {
            var query = "SELECT * FROM BusDrivers WHERE Id=@Id";

            using (var connection = _context.CreateConnection())
            {
                var driver = await connection.QuerySingleOrDefaultAsync<ManageDrivers>(query, new { id });

                return driver;
            }
        }

        public async Task<IEnumerable<ManageDrivers>> GetDrivers()
        {
            var query = "Select * FROM BusDrivers";
            using (var connection = _context.CreateConnection())
            {
                var drivers = await connection.QueryAsync<ManageDrivers>(query);
                return drivers.ToList();

            }
        }

        public async Task UpdateDriver(int id, ManageDrivers driver)
        {
            var query = "UPDATE BusDrivers SET Email=@Email, FirstName=@FirstName, LastName=@LastName WHERE Id=@Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Email", driver.Email, DbType.String);
            parameters.Add("FirstName", driver.FirstName, DbType.String);
            parameters.Add("LastName", driver.LastName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
