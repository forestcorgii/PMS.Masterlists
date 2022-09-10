using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Exceptions;
using Pms.Employees.Domain.Services;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Pms.Employees.Tests.Seeder;

namespace Pms.Employees.Tests.ServiceLayer.EfCore
{
    public class ManageEmployeeServiceTests
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        private IManageEmployeeService _service;

        private string eeId;
        private Employee expectedEmployee;

        public ManageEmployeeServiceTests()
        {
            _factory = new EmployeeDbContextFactoryFixture();
            _service = new EmployeeManager(_factory);

            eeId = "ABCD";
            expectedEmployee = AddSeedEmployee(eeId, "P1A", "CHK", "SOFTWARE", "000000001", "00000000000001");
        }

        [Fact]
        public void BankInformationShouldNotUpdateGeneralInformation()
        {
            try
            {
                IBankInformation bankInfo = expectedEmployee;

                _service.Save(bankInfo);
                
                using EmployeeDbContext context = _factory.CreateDbContext();
                Employee actualEmployee = context.Employees.Where(ee => ee.EEId == eeId).FirstOrDefault();

                context.Employees.Remove(actualEmployee);
                context.SaveChanges();

                Assert.NotNull(actualEmployee);
                Assert.False(actualEmployee.Location == expectedEmployee.Location);
            }
            catch (InvalidEmployeeFieldValueException ex)
            {
                Console.WriteLine(ex.Value);
            }
        }

        [Fact]
        public void GeneralInformationShouldNotUpdateBankInformation()
        {
            try { 
            IPersonalInformation bankInfo = expectedEmployee;

            _service.Save(bankInfo);

            using EmployeeDbContext context = _factory.CreateDbContext();
            Employee actualEmployee = context.Employees.Where(ee => ee.EEId == eeId).FirstOrDefault();

            context.Employees.Remove(actualEmployee);
            context.SaveChanges();


            Assert.NotNull(actualEmployee);
            Assert.False(actualEmployee.AccountNumber == expectedEmployee.AccountNumber);
        }
            catch (InvalidEmployeeFieldValueException ex)
            {
                Console.WriteLine(ex.Value);
            }
}

        [Fact]
        public void ShouldThrowExceptionWhenAddingEmployee()
        {
            Assert.Throws<EmptyEEIdException>(() =>
            {
                IBankInformation employee = new Employee();
                _service.Save(employee);
            });
        }

    }
}
