using Microsoft.EntityFrameworkCore;
using Payroll.Employees.Persistence;
using Payroll.Employees.ServiceLayer.EfCore.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.Concrete
{
    public class UtilityService
    {
        private EmployeeDbContext Context;
        public UtilityService(EmployeeDbContext context) =>
            Context = context;


        public IEnumerable<string> GetEmployeePayrollCodes() =>
            Context.Employees.AsNoTracking().ExtractPayrollCodes();

        public IEnumerable<string> GetEmployeeBankCategory(string payrollCode) =>
            Context.Employees.AsNoTracking().ExtractBankCategories(payrollCode);
    }
}
