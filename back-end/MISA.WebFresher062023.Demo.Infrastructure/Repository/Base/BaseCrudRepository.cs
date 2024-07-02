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
    public abstract class BaseCrudRepository<TEntity, TKey> : BaseReadOnlyRepository<TEntity, TKey>, ICrudRepository<TEntity, TKey> where TEntity : TEntity<TKey>
    {
        protected BaseCrudRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var connection = new MySqlConnection(ConnectionString);
            var sql = @"
                    INSERT INTO Employee (EmployeeId, EmployeeCode, FullName, Gender, DateOfBirth, DepartmentId)
                    VALUES (@EmployeeId, @EmployeeCode, @FullName, @Gender, @DateOfBirth, @DepartmentId)
                ";
            var result = await connection.ExecuteAsync(sql, entity);
            if (result == 0)
            {
                throw new Exception("Thêm nhân viên thất bại!");
            }
            return entity;
        }
        /// <summary>
        /// Hàm sửa thông tin nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<TEntity> UpdateAsync(TKey id, TEntity entity)
        {
            // Kiểm tra xem nhân viên có tồn tại không
            var connection = new MySqlConnection(ConnectionString);
            var existingEmployee = await GetAsync(id);
            if (existingEmployee == null)
            {
                throw new NotFoundException("Nhân viên không tồn tại");
            }
            // Thực hiện các kiểm tra logic khác trước khi cập nhật nhân viên
            var sql = @"
                        UPDATE Employee
                        SET EmployeeCode = @EmployeeCode,
                            Fullname = @Fullname,
                            Gender = @Gender,
                            DateOfBirth = @DateOfBirth,
                            DepartmentId = @DepartmentId
                            WHERE EmployeeId = @EmployeeId;
                        ";
            var param = new DynamicParameters();
            param.Add("EmployeeId", id);


            var result = await connection.ExecuteAsync(sql, param);
            if (result == 0)
            {
                throw new Exception("Sửa nhân viên không thành công!");
            }
            return entity;
        }
        /// <summary>
        /// Hàm xóa 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần xóa</param>
        /// <returns>Kết quả xóa</returns>
        /// Created by: dtthanh (22/08/2023)
        public async Task<int> DeleteAsync(TEntity entity)
        {
            var connection = new MySqlConnection(ConnectionString);
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @id;";
            var param = new DynamicParameters();
            param.Add("id", entity.GetId());
            var result = await connection.ExecuteAsync(sql, param);
            return result;
        }
        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="entities">Bản ghi cần xóa</param>
        /// <returns>Kết quả xóa</returns>
        /// Created by: dtthanh (22/08/2023)
        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            var connection = new MySqlConnection(ConnectionString);
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id IN @ids;";
            var param = new DynamicParameters();
            param.Add("ids", entities.Select(entity => entity.GetId()));
            var result = await connection.ExecuteAsync(sql, param);
            return result;

        }
    }
}
