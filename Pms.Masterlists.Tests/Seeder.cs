using Pms.Masterlists.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Tests
{
    public static class Seeder
    {
        public static Employee AddSeedEmployee(string eeId, string payrollCode, string bankCategory, string location, string accountNumber, string cardNumber)
        {
            Employee employee = new();
                employee .EEId = eeId;
            employee.PayrollCode = payrollCode;
            employee.BankCategory = bankCategory;
            employee.Location = location;
            employee.AccountNumber = accountNumber;
            employee.CardNumber = cardNumber;
            return employee;
        }

    }
}
