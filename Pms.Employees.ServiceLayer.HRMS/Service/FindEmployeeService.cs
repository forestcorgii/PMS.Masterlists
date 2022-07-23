using Microsoft.Extensions.Configuration;
using Pms.Employees.Domain;
using Pms.Employees.ServiceLayer.HRMS.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.HRMS.Service
{
    public class FindEmployeeService
    {
        private readonly HRMSAdapter? HRMSAdapter;
        public FindEmployeeService(HRMSAdapter hrmsAdapter)
        {
            HRMSAdapter = hrmsAdapter;
        }

        public async Task<Employee?> GetEmployeeAsync(string EEId, string site = "MANILA")
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

            if (pCode.Contains("K12AA")) { return "K12A"; }
            if (pCode.Contains("K12AT")) { return "K12"; }

            if (pCode.Contains("K12A")) { return "K12A"; }
            if (pCode.Contains("K12")) { return "K12"; }

            if (pCode.Contains("K13")) { return "K13"; }
            if (pCode.Contains("P1A")) { return "P1A"; }
            if (pCode.Contains("P4A")) { return "P4A"; }
            if (pCode.Contains("P7A")) { return "P7A"; }
            if (pCode.Contains("P10A")) { return "P10A"; }
            if (pCode.Contains("P11A")) { return "P11A"; }

            if (pCode == "") { pCode = "NOCODE"; }

            return pCode;
        }

        private static string ParseBankCategory(string payrollCode, string bankCategory)
        {
            if (payrollCode.Contains("ATM2")) { return "ATM2"; }
            if (payrollCode.Contains("ATM") || payrollCode.Contains("ATM1")) { return "ATM1"; }
            if (payrollCode.Contains("CHK") || payrollCode.Contains("NO BANK") || payrollCode.Contains("CHEQUE")) { return "CHK"; }
            if (payrollCode.Contains("CASHCARD") || payrollCode.Contains("CCARD")) { return "CCARD"; }

            string bankCat = bankCategory;
            switch (bankCat)
            {
                case "ATM":
                case "ATM1":
                    return "ATM1";

                case "ATM2":
                    return "ATM2";

                case "CHECK":
                case "CHEQUE":
                case "NO BANK":
                    return "CHK";

                case "CASHCARD":
                case "CCARD":
                    return "CCARD";
            }
            return "CHK";
        }
    }
}
