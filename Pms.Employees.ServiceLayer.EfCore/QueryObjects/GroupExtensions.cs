using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.EfCore.QueryObjects
{
    public static class GroupExtensions
    {
        public static List<string> ExtractBankCategories(this IQueryable<Employee> employees) =>
            employees.ToList().Where(ee => ee.BankCategory != "")
                .GroupBy(e => e.BankCategory)
                .Select(e => e.First())
                .OrderBy(ee=>ee.BankCategory)
                .Select(ee => ee.BankCategory).ToList();

        public static List<string> ExtractBankCategories(this IQueryable<Employee> employees, string payrollCode) =>
            employees.ToList().Where(ee => ee.BankCategory != "")
                .Where(e => e.PayrollCode == payrollCode)
                .GroupBy(e => e.BankCategory)
                .Select(e => e.First())
                .OrderBy(ee=>ee.BankCategory)
                .Select(ee => ee.BankCategory).ToList();


        public static List<string> ExtractPayrollCodes(this IQueryable<Employee> employee) =>
            employee.ToList().Where(ee => ee.PayrollCode != "")
                .GroupBy(e => e.PayrollCode)
                .Select(e => e.First())
                .OrderBy(ee => ee.PayrollCode)
                .Select(ee => ee.PayrollCode).ToList();
    }
}
