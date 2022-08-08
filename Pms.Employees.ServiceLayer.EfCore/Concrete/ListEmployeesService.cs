using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore;
using Pms.Employees.ServiceLayer.EfCore.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.Concrete
{
    public class ListEmployeesService : IEmployeeProvider
    {
        private EmployeeDbContextFactory _factory;
        public ListEmployeesService(EmployeeDbContextFactory factory) =>
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
    }
}



