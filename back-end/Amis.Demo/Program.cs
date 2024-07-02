using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher062023.Demo.Application;
using MISA.WebFresher062023.Demo.Domain;
using MISA.WebFresher062023.Demo.Infrastructure;
using MISA.WebFresher062023.Demo.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values.SelectMany(x => x.Errors);
        return new BadRequestObjectResult(new BaseException()
        {
            ErrorCode = 404,
            UserMessage = "Lỗi nhập từ người dùng",
            DevMessage = "Lỗi nhập từ người dùng",
            TraceId = "",
            MoreInfo = "",
            Errors = errors
        }.ToString() ?? "");
    };
});
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddScoped<IEmployeeRepository>(provider => new EmployeeRepository(connectionString));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();