using Payroll.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.EfCore.QueryObjects
{
    public static class GroupBankCategories
    {
        public static List<string> ExtractBankCategories(this IQueryable<Employee> employees) =>
            employees
                .GroupBy(e => e.BankCategory)
                .Select(e => e.First())
                .Select(ee => ee.BankCategory).ToList();

        public static List<string> ExtractBankCategories(this IQueryable<Employee> employees, string payrollCode) =>
            employees
                .Where(e => e.PayrollCode == payrollCode)
                .GroupBy(e => e.BankCategory)
                .Select(e => e.First())
                .Select(ee => ee.BankCategory).ToList();

    }
}
