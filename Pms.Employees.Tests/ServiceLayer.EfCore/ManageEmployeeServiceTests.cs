using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Exceptions;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.Concrete;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pms.Employees.Tests.ServiceLayer.EfCore
{
    public class ManageEmployeeServiceTests
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        private IManageEmployeeService _service;

        public ManageEmployeeServiceTests()
        {
            _factory = new EmployeeDbContextFactoryFixture();
            _service = new ManageEmployeeService(_factory);
        }

        [Fact]
        public void ShouldThrowExceptionWhenAddingEmployee()
        {
            Assert.Throws<EmptyEEIdException>(() =>
            {
                _service.CreateOrEditAndSave(new Employee());
            });
        }

    }
}
