using Xunit;
using Microsoft.EntityFrameworkCore;
using Pms.Masterlists.Persistence;
using Pms.Masterlists.ServiceLayer.EfCore;
using Pms.Masterlists.Domain.Entities.Employees;

namespace Pms.Masterlists.Tests.ServiceLayer.EfCore
{
    public class EmployeeProviderTests
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        private EmployeeProvider _service;

        public EmployeeProviderTests()
        {
            _factory = new EmployeeDbContextFactoryFixture();
            _service = new EmployeeProvider(_factory);
        }


        [Fact]
        public void FindEmployeeTest()
        {
            string expectedEEId = "DYYJ";
            Employee actualEmployee = _service.FindEmployee(expectedEEId);
            Assert.Equal(actualEmployee.EEId, expectedEEId);
        }

        [Fact]
        public void ShouldReturnEmployeesUsingGetEmployees()
        {

        }
    }
}
