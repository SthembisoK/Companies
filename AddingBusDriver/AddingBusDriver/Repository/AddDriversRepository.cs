using AddingBusDriver.Interfaces;
using AddingBusDriver.Models;
using Dapper;
using GetBusDriver.Context;
using System.Data;

namespace AddingBusDriver.Repository
{
    public class AddDriversRepository : IAddDriversRepository
    {
        private readonly DBContext _context;
        public AddDriversRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<Driver> GetDrivers(Driver driver)
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
                var createdDriver = new Driver
                {
                    Id = id,
                    Email = driver.Email,
                    FirstName = driver.FirstName,
                    LastName = driver.LastName
                    
                };
                return createdDriver;
            }
        }
    }
}
