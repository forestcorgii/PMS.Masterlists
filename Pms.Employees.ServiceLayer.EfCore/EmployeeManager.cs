using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Exceptions;
using Pms.Employees.Domain.Services;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer
{
    public class EmployeeManager : IManageEmployeeService
    {
        private IDbContextFactory<EmployeeDbContext> _factory;

        public EmployeeManager(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        private void Validate(string eeId)
        {
            if (eeId == "")
                throw new EmptyEEIdException(eeId);
        }

        public void Save(IGeneralInformation generalInfo)
        {
            Validate(generalInfo.EEId);

            Employee employee = new()
            {
                EEId = generalInfo.EEId,
                FirstName = generalInfo.FirstName,
                LastName = generalInfo.LastName,
                MiddleName = generalInfo.MiddleName,
                BirthDate = generalInfo.BirthDate,

                PayrollCode = generalInfo.PayrollCode,
                BankCategory = generalInfo.BankCategory,
                Location = generalInfo.Location,
                Site = generalInfo.Site,
                
                Pagibig = generalInfo.Pagibig,
                PhilHealth = generalInfo.PhilHealth,
                SSS = generalInfo.SSS,
                TIN = generalInfo.TIN,
            };

            AddOrUpdate(employee);
        }

        public void Save(IBankInformation bankInfo)
        {
            Validate(bankInfo.EEId);

            Employee employee = new()
            {
                EEId = bankInfo.EEId,
                AccountNumber = bankInfo.AccountNumber,
                CardNumber = bankInfo.CardNumber,
                BankName = bankInfo.BankName,
            };

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
