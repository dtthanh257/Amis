using System;
namespace MISA.WebFresher062023.Demo.Domain
{
	public class NotFoundException : Exception
	{
        /// <summary>
        /// Mã lỗi
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public int ErrorCode { get; set; }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public NotFoundException() { }

        /// <summary>
        /// Hàm khởi tạo với mã lỗi
        /// </summary>
        /// <param name="errorCode">mã lỗi</param>
        /// Author: dtthanh (15/08/2023)
        public NotFoundException(int errorCode) { ErrorCode = errorCode; }

        /// <summary>
        /// Hàm khởi tạo với tin nhắn lỗi
        /// </summary>
        /// <param name="message">tin nhắn lỗi</param>
        /// Author: dtthanh (15/08/2023)
        public NotFoundException(string message) : base(message) { }

        /// <summary>
        /// Hàm khởi tạo với mã lỗi và tin nhắn lỗi
        /// </summary>
        /// <param name="message">tin nhắn lỗi</param>
        /// <param name="errorCode">mã lỗi</param>
        /// Author: dtthanh (15/08/2023)
        public NotFoundException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

