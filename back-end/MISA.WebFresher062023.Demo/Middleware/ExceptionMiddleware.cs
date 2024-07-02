using MISA.WebFresher062023.Demo.Domain;
namespace MISA.WebFresher062023.Demo.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// hàm khởi tạo
        /// </summary>
        /// <param name="next"></param>
        /// Author: dtthanh (15/08/2023)
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Hàm xử lý con exception invoke
        /// </summary>
        /// <param name="context">http context</param>
        /// <returns></returns>
        /// Author: dtthanh (15/08/2023)
        public async Task Invoke(HttpContext context)
        {
            try { await _next(context); }
            catch (Exception ex) { await HandleExceptionAsync(context, ex); }
        }

        /// <summary>
        /// Hàm xử lý exception
        /// </summary>
        /// <param name="context">http context</param>
        /// <param name="exception">lỗi</param>
        /// <returns></returns>
        /// Author: dtthanh (15/08/2023)
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";
            if (exception is NotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = ((NotFoundException)exception).ErrorCode,
                        UserMessage = "Không tìm thấy tài nguyên",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                    );
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = context.Response.StatusCode,
                        UserMessage = "Lỗi hệ thống",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                    );
            }
        }
    }
}