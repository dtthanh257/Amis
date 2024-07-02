using Dapper;
using MISA.WebFresher062023.Demo.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : TEntity<TKey>
    {
        protected readonly string ConnectionString;
        protected virtual string TableName { get; set; } = typeof(TEntity).Name;
        protected BaseReadOnlyRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var connection = new MySqlConnection(ConnectionString);
            var sql = $"SELECT * FROM {TableName};";
            var result = await connection.QueryAsync<TEntity>(sql);
            return result.ToList();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            var entity = await FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            return entity;
        }
        public async Task<TEntity?> FindAsync(TKey id)
        {
            var connection = new MySqlConnection(ConnectionString);
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @id;";
            var param = new DynamicParameters();
            param.Add("id", id);
            var result = await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param);
            return result;
        }
    }
}
