﻿using Pms.Masterlists.Domain.Entities.Employees;

namespace Pms.Masterlists.Tests
{
    public static class Seeder
    {
        public static Employee AddSeedEmployee(string eeId, string payrollCode, string bankCategory, string location, string accountNumber, string cardNumber)
        {
            Employee employee = new();
            employee.EEId = eeId;
            employee.PayrollCode = payrollCode;
            employee.Location = location;
            employee.AccountNumber = accountNumber;
            employee.CardNumber = cardNumber;
            return employee;
        }

    }
}
