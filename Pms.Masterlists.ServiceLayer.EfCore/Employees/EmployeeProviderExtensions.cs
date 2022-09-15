using Pms.Masterlists.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.ServiceLayer.EfCore
{
    public static class EmployeeProviderExtensions
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


        public static IQueryable<Employee> FilterBySearchString(this IQueryable<Employee> employees, string filter) =>
         employees.Where(ee =>
             filter == "" ||
             ee.EEId.Contains(filter) ||
             ee.FirstName.Contains(filter) ||
             ee.LastName.Contains(filter) ||
             ee.MiddleName.Contains(filter) ||
             ee.Location.Contains(filter)
        );

        public static IQueryable<Employee> FilterByPayrollCode(this IQueryable<Employee> employees, string payrollCode) =>
            employees.Where(ee => ee.PayrollCode == payrollCode);
    }
}
