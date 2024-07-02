using MISA.WebFresher062023.Demo.Application;
using MISA.WebFresher062023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Application
{
    public class DepartmentService : BaseReadOnlyService<DepartmentEntity, Guid, DepartmentDto>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository repository) : base(repository)
        {
            _departmentRepository = repository;
        }

        protected override DepartmentDto MapEntityToEntityDto(DepartmentEntity entity)
        {
            var departmentDto = new DepartmentDto()
            {
                DepartmentId = entity.DepartmentId,
                DepartmentName = entity.DepartmentName,
            };
            return departmentDto;
        }
    }
}
