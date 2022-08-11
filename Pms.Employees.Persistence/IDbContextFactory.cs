using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Persistence
{
    public interface IDbContextFactory
    {
        EmployeeDbContext CreateDbContext();
        }
}
