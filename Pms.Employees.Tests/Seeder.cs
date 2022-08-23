using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Tests
{
    public static class Seeder
    {
        public static Employee AddSeedEmployee(string eeId, string payrollCode, string bankCategory, string location, string accountNumber, string cardNumber)
        {
            return new Employee()
            {
                EEId = eeId,
                PayrollCode = payrollCode,
                BankCategory = bankCategory,
                Location = location,
                AccountNumber = accountNumber,
                CardNumber = cardNumber
            };
        }
    }
}
