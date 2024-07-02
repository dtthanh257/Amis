using System;
using MISA.WebFresher062023.Demo.Application;
using MISA.WebFresher062023.Demo.Domain;

namespace MISA.WebFresher062023.Demo.Application
{
	public class EmployeeService : BaseCrudService<EmployeeEntity, Guid, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="employeeRepository">Interface employee repository</param>
        /// Author: dtthanh (15/08/2023)
        public EmployeeService(IEmployeeRepository repository) : base((ICrudRepository<EmployeeEntity, Guid>)repository)
        {
            _employeeRepository = repository;
        }

        public async Task<bool> CheckDuplicateCodeAsync(string code)
        {
            var employee = await _employeeRepository.FindByCodeAsync(code);
            if (employee == null) { return false; }
            else { return true; }
        }

        public override Task<EmployeeEntity> MapEntityCreateDtoToEntity(EmployeeCreateDto entityCreateDto)
        {
            throw new NotImplementedException();
        }

        public override Task<EmployeeEntity> MapEntityUpdateDtoToEntity(EmployeeUpdateDto entityUpdateDto)
        {
            throw new NotImplementedException();
        }

        protected override EmployeeDto MapEntityToEntityDto(EmployeeEntity entity)
        {
            var entityDto = new EmployeeDto()
            {
                EmployeeId = entity.EmployeeId,
                EmployeeCode = entity.EmployeeCode,
                DateOfBirth = entity.DateOfBirth,
                Gender = entity.Gender
            };
            return entityDto;
        }
    }
}

