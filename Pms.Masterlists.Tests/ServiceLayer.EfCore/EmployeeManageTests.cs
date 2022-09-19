using Microsoft.EntityFrameworkCore;
using Pms.Masterlists.Domain.Entities.Employees;
using Pms.Masterlists.Persistence;
using Pms.Masterlists.ServiceLayer.EfCore;
using System.Linq;
using Xunit;
using static Pms.Masterlists.Tests.Seeder;

namespace Pms.Masterlists.Tests.ServiceLayer.EfCore
{
    public class EmployeeManageTests
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        private EmployeeManager _service;

        private string eeId;
        private Employee expectedEmployee;

        public EmployeeManageTests()
        {
            _factory = new EmployeeDbContextFactoryFixture();
            _service = new EmployeeManager(_factory);

            eeId = "ABCD";
            expectedEmployee = AddSeedEmployee(eeId, "M-P1A", "CHK", "SOFTWARE", "000000001", "00000000000001");
        }

        [Fact]
        public void Bank_Informations_should_not_Update_General_Information()
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

        [Fact]
        public void General_Information_should_not_Update_Bank_Information()
        {
            IPersonalInformation bankInfo = expectedEmployee;

            _service.Save(bankInfo);

            using EmployeeDbContext context = _factory.CreateDbContext();
            Employee actualEmployee = context.Employees.Where(ee => ee.EEId == eeId).FirstOrDefault();

            context.Employees.Remove(actualEmployee);
            context.SaveChanges();


            Assert.NotNull(actualEmployee);
            Assert.False(actualEmployee.AccountNumber == expectedEmployee.AccountNumber);
        }

    }
}
