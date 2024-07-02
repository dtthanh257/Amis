using MISA.WebFresher062023.Demo.Application;

namespace MISA.WebFresher062023.Demo.Controllers
{
    public class DepartmentsController : BaseReadOnlyController<Guid, DepartmentDto>
    {
        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
        }
    }
}
