using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer
{
    public class EmployeeProvider 
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
            IQueryable<Employee> employees = GetEmployees();
            
            if (payrollCode != "")
                employees = employees.FilterByPayrollCode(payrollCode);
            else if (searchString != "")
                employees = employees.FilterBySearchString(searchString);

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

        public Employee FindEmployee(string eeId)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Employees.Find(eeId);
        }
    }
}



