using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher062023.Demo.Application;

namespace MISA.WebFresher062023.Demo
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseReadOnlyController<TKey, TEntityDto> : ControllerBase where TEntityDto : class
    {

        public readonly IReadOnlyService<TKey, TEntityDto> ReadOnlyService;
        protected BaseReadOnlyController(IReadOnlyService<TKey, TEntityDto> readOnlyService)
        {
            ReadOnlyService = readOnlyService;
        }
        /// <summary>
        /// Hàm lấy về danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Created by: dtthanh (22/08/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await ReadOnlyService.GetAllAsync();

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Hàm lấy về 1 bản ghi với id
        /// </summary>
        /// <returns>1 bản ghi với id</returns>
        /// Created by: dtthanh (22/08/2023)
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(TKey id)
        {
            var result = await ReadOnlyService.GetAsync(id);

            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
