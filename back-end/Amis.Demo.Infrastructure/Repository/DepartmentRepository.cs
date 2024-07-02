using MISA.WebFresher062023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Infrastructure
{
    public class DepartmentRepository : BaseReadOnlyRepository<DepartmentEntity, Guid>, IDepartmentRepository
    {
        public new string TableName = "Department";
        public DepartmentRepository(string connectionString) : base(connectionString)
        {
        }
    }
}