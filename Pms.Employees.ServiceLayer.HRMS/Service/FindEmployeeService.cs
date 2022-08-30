using Microsoft.Extensions.Configuration;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Services;
using Pms.Employees.ServiceLayer.HRMS.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.HRMS.Service
{
    public class FindEmployeeService : IEmployeeFinder
    {
        private readonly HRMSAdapter HRMSAdapter;
        public FindEmployeeService(HRMSAdapter hrmsAdapter)
        {
            HRMSAdapter = hrmsAdapter;
        }

        public async Task<Employee> GetEmployeeAsync(string EEId, string site = "MANILA")
        {
            if (HRMSAdapter is not null)
            {
                Employee employee = await HRMSAdapter.GetEmployeeFromHRMS<Employee>(EEId, site);
                if (employee is not null)
                {
                    employee.BankCategory = ParseBankCategory(employee.PayrollCode, employee.BankCategory);
                    employee.PayrollCode = ParsePayrollCode(employee.PayrollCode);
                    return employee;
                }
                return null;
            }
            throw new Exception("HRMS Service is not set.");
        }



        private static string ParsePayrollCode(string payroll_code)
        {
            string pCode = payroll_code.Split('-')[0].Replace("PAY", "P").Trim();
            pCode = Regex.Match(pCode, "([BLKP]{1,2})([1-9]{1,2})(A?)").Value;

            return pCode;
        }

        private static string ParseBankCategory(string payrollCode, string bankCategory)
        {
            if (payrollCode.Contains("ATM2") || bankCategory.Contains("ATM2")) { return "ATM2"; }
            if (payrollCode.Contains("ATM") || bankCategory.Contains("ATM")) { return "ATM1"; }
            if (payrollCode.Contains("CHK") || payrollCode.Contains("NO BANK") || payrollCode.Contains("CHEQUE")) { return "CHK"; }
            if (payrollCode.Contains("CASHCARD") || payrollCode.Contains("CCARD")) { return "CCARD"; }

            string bankCat = $"{payrollCode} {bankCategory}";
            bankCat = Regex.Replace(bankCat, "(CASHCARD)", "CCARD");
            bankCat = Regex.Replace(bankCat, "(CHECK|CHEQUE|NO BANK)", "CHK");

            return Regex.Match(bankCat, "(CHK|ATM1|ATM2|CCARD)").Value;
        }
    }
}
