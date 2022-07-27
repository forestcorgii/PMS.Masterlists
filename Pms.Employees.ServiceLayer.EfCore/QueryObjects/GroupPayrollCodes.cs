using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.EfCore.QueryObjects
{
    public static class GroupPayrollCodes
    {
        public static List<string> ExtractPayrollCodes(this IQueryable<Employee> employee) =>
            employee.ToList().Where(ee => ee.PayrollCode != "")
            .GroupBy(e => e.PayrollCode)
            .Select(e => e.First())
            .OrderBy(ee=>ee.PayrollCode)
            .Select(ee => ee.PayrollCode).ToList();

    }
}
