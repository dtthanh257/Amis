using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Application
{
    public interface IReadOnlyService<TKey, TEntityDto> where TEntityDto : class
    {
        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        /// Created by: dtthanh (15/08/2023)
        Task<List<TEntityDto>> GetAllAsync();
        /// <summary>
        /// Hàm lấy bản ghi theo id
        /// </summary>
        /// <param name="entityId">id bản ghi</param>
        /// <returns>bản ghi</returns>
        /// Created by: dtthanh (15/08/2023)
        Task<TEntityDto> GetAsync(TKey id);
    }
}
