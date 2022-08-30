using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Services;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer
{
    public class EmployeeProvider : IProvideEmployeeService
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        public EmployeeProvider(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        public IQueryable<Employee> GetEmployees()
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Employees.AsNoTracking();
        }

        public IQueryable<Employee> FilterEmployees(string searchString, string payrollCode)
        {
            IQueryable<Employee> employees;
            if (searchString != "")
                employees = GetEmployees().FilterByPayrollCode(payrollCode).FilterBySearchString(searchString);
            else
                employees = GetEmployees().FilterByPayrollCode(payrollCode);

            return employees;
        }


        public IEnumerable<string> ListEmployeePayrollCodes() =>
            GetEmployees().ExtractPayrollCodes();

        public IEnumerable<string> ListEmployeeBankCategory(string payrollCode) =>
            GetEmployees().ExtractBankCategories(payrollCode);

        public bool EmployeeExists(string eeId)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Employees.Any(ee => ee.EEId == eeId);
        }
    }
}



