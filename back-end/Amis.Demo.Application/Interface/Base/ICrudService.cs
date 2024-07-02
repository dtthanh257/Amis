using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Application
{
    public interface ICrudService<TKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IReadOnlyService<TKey, TEntityDto> where TEntityDto : class where TEntityCreateDto : class where TEntityUpdateDto : class
    {
        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">bản ghi</param>
        /// <returns>bản ghi được thêm</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<TEntityDto> InsertAsync(TEntityCreateDto entity);

        /// <summary>
        /// Hàm sửa một bản ghi
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <param name="entity">bản ghi</param>
        /// <returns>bản ghi được sửa</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<TEntityDto> UpdateAsync(TKey id, TEntityUpdateDto entityUpdateDto);

        /// <summary>
        /// Hàm xoá 1 bản ghi
        /// </summary>
        /// <param name="id">id bản ghi</param>
        /// <returns>1 nếu bản ghi đã xoá</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<int> DeleteAsync(TKey id);

        /// <summary>
        /// Hàm xoá nhiều bản ghi
        /// </summary>
        /// <param name="ids">danh sách id bản ghi</param>
        /// <returns>1 nếu bản ghi đã xoá</returns>
        /// Created by: dtthanh (22/08/2023)
        Task<int> DeleteManyAsync(List<TKey> ids);

        /// <summary>
        /// Hàm thêm
        /// </summary>
        /// <typeparam name="TEntityCreateDto">Kiểu dữ liệu của bản ghi</typeparam>
        /// <param name="entityCreateDto">bản ghi được thêm</param>
        /// <returns>trả về bản ghi</returns>
        /// Created by: dtthanh (22/08/2023)
        Task AddAsync<TEntityCreateDto>(TEntityCreateDto entityCreateDto) where TEntityCreateDto : class;
    }
}
