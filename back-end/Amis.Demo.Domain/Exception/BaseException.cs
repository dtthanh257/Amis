using System;
using System.Text.Json;

namespace MISA.WebFresher062023.Demo.Domain
{
	public class BaseException
	{
        #region Properties
        /// <summary>
        /// mã lỗi
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public int ErrorCode { get; set; }

        /// <summary>
        /// tin nhắn cho người phát triển
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string? DevMessage { get; set; }

        /// <summary>
        /// tin nhắn cho user
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string? UserMessage { get; set; }

        /// <summary>
        /// id 
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string? TraceId { get; set; }

        /// <summary>
        /// thông tin thêm
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Lỗi
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public Object? Errors { get; set; }
        #endregion
        #region Methods
        /// <summary>
        /// chuyển thành string
        /// </summary>
        /// <returns></returns>
        /// Author: dtthanh (15/08/2023)
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        #endregion
    }
}

