using Payroll.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.EfCore.QueryObjects
{
    public static class GroupPayrollCodes
    {
        public static List<string> ExtractPayrollCodes(this IQueryable<Employee> employee) =>
            employee
            .GroupBy(e => e.PayrollCode)
            .Select(e => e.First())
            .Select(ee => ee.PayrollCode).ToList();

    }
}
