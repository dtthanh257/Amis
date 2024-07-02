using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Domain
{
    public interface IReadOnlyRepository<TEntity, TKey> where TEntity : TEntity<TKey>
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Nhân viên</returns>
        /// Created by: dtthanh (23/08/2023)
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Hàm lấy một bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Created by: dtthanh (23/08/2023)
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Hàm lấy một bản ghi theo ID
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Created by: dtthanh (23/08/2023)
        Task<TEntity?> FindAsync(TKey id);
    }
}
