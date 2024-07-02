using System;
namespace MISA.WebFresher062023.Demo.Domain
{
	public class ConflictException : Exception
    {
        /// <summary>
        /// mã lỗi
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        /// Author: dtthanh (15/08/2023)
        public ConflictException() { }

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        /// <param name="errorCode">mã lỗi</param>
        /// Author: dtthanh (15/08/2023)
        public ConflictException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        /// <param name="message">tin nhắn lỗi</param>
        /// Author: dtthanh (15/08/2023)
        public ConflictException(string message) : base(message) { }
        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        /// <param name="message">tin nhắn lỗi</param>
        /// <param name="errorCode">mã lỗi</param>
        /// Author: dtthanh (15/08/2023)
        public ConflictException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

