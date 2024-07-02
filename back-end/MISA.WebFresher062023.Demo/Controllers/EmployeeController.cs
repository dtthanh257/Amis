using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using MISA.WebFresher062023.Demo.Application;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WebFresher062023.Demo
{
    [Route("api/v1/Employees")]
    [ApiController]
    public class EmployeeController : BaseCrudController<Guid, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("exist-code")]
        public async Task<bool> CheckDuplicatedCode(string code)
        {
            var result = await _employeeService.CheckDuplicateCodeAsync(code);

            return result;
        }
    }
}