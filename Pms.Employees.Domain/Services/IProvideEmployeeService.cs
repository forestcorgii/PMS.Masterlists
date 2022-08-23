using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain.Services
{
    public interface IProvideEmployeeService
    {
        bool EmployeeExists(string eeId);

        IQueryable<Employee> GetEmployees();

        IQueryable<Employee> FilterEmployees(string searchString, string payrollCode);

        IEnumerable<string> ListEmployeePayrollCodes();

        IEnumerable<string> ListEmployeeBankCategory(string payrollCode);
    }
}
