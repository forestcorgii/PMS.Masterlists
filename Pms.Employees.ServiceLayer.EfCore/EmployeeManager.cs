using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Exceptions;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer
{
    public class EmployeeManager
    {
        private IDbContextFactory<EmployeeDbContext> _factory;

        public EmployeeManager(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        private void Validate(string eeId)
        {
            if (eeId is null || eeId == "")
                throw new EmptyEEIdException(eeId);
        }

        public void Save(IPersonalInformation generalInfo)
        {
            Validate(generalInfo.EEId);

            EmployeeDbContext Context = _factory.CreateDbContext();
            Employee employee = Context.Employees.Where(ee => ee.EEId == generalInfo.EEId).FirstOrDefault();
            if (employee is null)
                employee = new() { EEId = generalInfo.EEId };

            employee.EEId = generalInfo.EEId;
            employee.FirstName = generalInfo.FirstName.Trim();
            employee.LastName = generalInfo.LastName.Trim();
            employee.MiddleName = generalInfo.MiddleName.Trim();
            employee.BirthDate = generalInfo.BirthDate;


            //employee.PayrollCode = generalInfo.PayrollCode;
            employee.BankCategory = generalInfo.BankCategory;
            employee.Location = generalInfo.Location;
            employee.Site = generalInfo.Site;


            //employee.Pagibig = generalInfo.Pagibig;
            //employee.PhilHealth = generalInfo.PhilHealth;
            //employee.SSS = generalInfo.SSS;
            //employee.TIN = generalInfo.TIN;
            employee.Active = generalInfo.Active;

            employee.ValidatePersonalInformation();

            AddOrUpdate(employee);
        }

        public void Save(IBankInformation bankInfo)
        {
            Validate(bankInfo.EEId);

            EmployeeDbContext Context = _factory.CreateDbContext();

            Employee employee = Context.Employees.Where(ee => ee.EEId == bankInfo.EEId).FirstOrDefault();
            if (employee is null)
                employee = new() { EEId = bankInfo.EEId };

            employee.AccountNumber = bankInfo.AccountNumber;
            employee.CardNumber = bankInfo.CardNumber;
            employee.Bank = bankInfo.Bank;
            employee.PayrollCode = bankInfo.PayrollCode;

            employee.ValidateBankInformation();

            if (!Context.PayrollCodes.Any(pc => pc.PayrollCodeId == bankInfo.PayrollCode))
                throw new InvalidEmployeeFieldValueException("Payroll Code", employee.PayrollCode, employee.EEId, "Unknown Payroll code.");

            Employee hasDuplicateAccountNumber = null;
            Employee hasDuplicateCardNumber = null;
            if (employee.Bank == Enums.BankChoices.LBP)
            {
                hasDuplicateAccountNumber = Context.Employees.Where(ee => ee.EEId != bankInfo.EEId && ee.AccountNumber == bankInfo.AccountNumber).FirstOrDefault();
                hasDuplicateCardNumber = Context.Employees.Where(ee => ee.EEId != bankInfo.EEId && ee.CardNumber == bankInfo.CardNumber).FirstOrDefault();
            }
            else if (employee.Bank != Enums.BankChoices.CHK)
                hasDuplicateAccountNumber = Context.Employees.Where(ee => ee.EEId != bankInfo.EEId && ee.AccountNumber == bankInfo.AccountNumber).FirstOrDefault();


            if (hasDuplicateAccountNumber is not null)
                throw new DuplicateBankInformationException(employee.EEId, hasDuplicateAccountNumber.EEId, "Account Number", hasDuplicateAccountNumber.AccountNumber);

            if (hasDuplicateCardNumber is not null)
                throw new DuplicateBankInformationException(employee.EEId, hasDuplicateCardNumber.EEId, "Card Number", hasDuplicateCardNumber.CardNumber);


            AddOrUpdate(employee);
        }

        public void Save(IGovernmentInformation governmentInfo)
        {
            Validate(governmentInfo.EEId);

            EmployeeDbContext Context = _factory.CreateDbContext();
            Employee employee = Context.Employees.Where(ee => ee.EEId == governmentInfo.EEId).FirstOrDefault();
            if (employee is null)
                employee = new() { EEId = governmentInfo.EEId };

            employee.Pagibig = governmentInfo.Pagibig;
            employee.PhilHealth = governmentInfo.PhilHealth;
            employee.SSS = governmentInfo.SSS;
            employee.TIN = governmentInfo.TIN;

            employee.ValidateGovernmentInformation();

            AddOrUpdate(employee);
        }

        public void Save(IEEDataInformation eeFileInfo)
        {
            Validate(eeFileInfo.EEId);

            EmployeeDbContext Context = _factory.CreateDbContext();
            Employee employee = Context.Employees.Where(ee => ee.EEId == eeFileInfo.EEId).FirstOrDefault();
            if (employee is null)
                employee = new() { EEId = eeFileInfo.EEId };

            employee.EEId = eeFileInfo.EEId;
            employee.FirstName = eeFileInfo.FirstName;
            employee.LastName = eeFileInfo.LastName;
            employee.MiddleName = eeFileInfo.MiddleName;
            employee.NameExtension = eeFileInfo.NameExtension;
            employee.BirthDate = eeFileInfo.BirthDate;

            employee.Pagibig = eeFileInfo.Pagibig;
            employee.PhilHealth = eeFileInfo.PhilHealth;
            employee.SSS = eeFileInfo.SSS;
            employee.TIN = eeFileInfo.TIN;

            employee.ValidateGovernmentInformation();
            employee.ValidatePersonalInformation();

            AddOrUpdate(employee);
        }



        private void AddOrUpdate(Employee employee)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            if (Context.Employees.Count(ee => ee.EEId == employee.EEId) > 0)
                Context.Update(employee);
            else
                Context.Add(employee);
            Context.SaveChanges();
        }
    }
}
