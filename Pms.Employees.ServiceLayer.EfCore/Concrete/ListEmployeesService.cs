using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.Concrete
{
   public class ListEmployeesService
    {
        private EmployeeDbContext Context;
        public ListEmployeesService(EmployeeDbContext context) =>
            Context = context;

        public IQueryable<Employee> GetEmployees() => 
            Context.Employees.AsNoTracking();

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



