using Payroll.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.EfCore.QueryObjects
{
    public static class FilterEmployees
    {
        public static IQueryable<Employee> FilterBySearchString(this IQueryable<Employee> employees, string filter) =>
            employees.Where(ee =>
                ee.EEId.Contains(filter) ||
                ee.FirstName.Contains(filter) ||
                ee.LastName.Contains(filter) ||
                ee.MiddleName.Contains(filter) ||
                ee.Location.Contains(filter) ||
                ee.BankName.Contains(filter)
           );

        public static IQueryable<Employee> FilterByPayrollCode(this IQueryable<Employee> employees, string payrollCode) =>
            employees.Where(ee => ee.PayrollCode == payrollCode);
    }
}
