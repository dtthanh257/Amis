using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Domain
{
    public interface ICrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : TEntity<TKey>
    {
        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Hàm sửa thông tin bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Bản ghi</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<TEntity> UpdateAsync(TKey id, TEntity entity);

        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần xóa</param>
        /// <returns>Kết quả: (0 - xóa bản ghi thât bại, 1 - xóa bản ghi thành công)</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách bản ghi cần xóa</param>
        /// <returns>Kết quả: (0 - xóa bản ghi thât bại, 1 - xóa bản ghi thành công)</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<int> DeleteManyAsync(List<TEntity> entities);
    }
}