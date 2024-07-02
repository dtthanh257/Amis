using System;
using MISA.WebFresher062023.Demo.Application;

namespace MISA.WebFresher062023.Demo.Application
{
    public interface IEmployeeService : ICrudService<Guid, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        Task<bool> CheckDuplicateCodeAsync(string code);

    }
}

