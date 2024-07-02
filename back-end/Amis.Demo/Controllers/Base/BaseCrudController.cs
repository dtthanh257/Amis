using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher062023.Demo.Application;

namespace MISA.WebFresher062023.Demo
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseCrudController<TKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyController<TKey, TEntityDto> where TEntityDto : class where TEntityCreateDto : class where TEntityUpdateDto : class
    {
        public readonly ICrudService<TKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> CrudService;
        public BaseCrudController(ICrudService<TKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> crudService) : base(crudService)
        {
            CrudService = crudService;
        }

        /// <summary>
        /// Phương thức thêm mới một bản ghi
        /// </summary>
        /// <param name="entityCreateDto">Bản ghi</param>
        /// <returns>Kết quả thêm</returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TEntityCreateDto entityCreateDto)
        {
            var result = await CrudService.InsertAsync(entityCreateDto);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Phương thức sửa một bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <param name="entityUpdateDto">Bản ghi cần cập nhật</param>
        /// <returns>Kết quả cập nhật</returns>
        /// Created by: dtthanh ( 22/08/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(TKey id, [FromBody] TEntityUpdateDto entityUpdateDto)
        {
            var result = await CrudService.UpdateAsync(id, entityUpdateDto);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Phương thức xoá một bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>Kết quả xoá thành công (true hoặc false)</returns>
        /// Created by: dtthanh(22/08/2023)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(TKey id)
        {
            var result = await CrudService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Phương thức xoá nhiều bản ghi
        /// </summary>
        /// <param name="ids">Danh sách Id bản ghi</param>
        /// <returns>Kết quả xoá thành công (true hoặc false)</returns>
        /// Created by: dtthanh (15/8/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] List<TKey> ids)
        {
            var result = await CrudService.DeleteManyAsync(ids);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
