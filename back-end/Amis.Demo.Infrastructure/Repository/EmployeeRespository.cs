using Dapper;
using MISA.WebFresher062023.Demo.Application;
using MISA.WebFresher062023.Demo.Domain;
using MySqlConnector;

namespace MISA.WebFresher062023.Demo.Infrastructure
{
    public class EmployeeRepository : BaseCrudRepository<EmployeeEntity, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<EmployeeEntity?> FindByCodeAsync(string code)
        {
            var connection = new MySqlConnection(ConnectionString);
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Code =@code;";
            var param = new DynamicParameters();
            param.Add("@code", code);
            var result = await connection.QuerySingleOrDefaultAsync<EmployeeEntity>(sql, param);
            return result;
        }
    }
}