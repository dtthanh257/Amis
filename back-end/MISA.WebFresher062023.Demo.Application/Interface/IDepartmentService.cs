﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Application
{
    public interface IDepartmentService : IReadOnlyService<Guid, DepartmentDto>
    {
    }
}
