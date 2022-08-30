using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pms.Employees.Persistence;
using Pms.Employees.Domain.Services;
using Pms.Employees.Tests;
using Pms.Employees.Domain;
using Pms.Employees.ServiceLayer.Files;
using Pms.Employees.ServiceLayer;

namespace Pms.Employees.Files.Tests
{
    public class ImportEmployeeServiceTests
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        private IManageEmployeeService _service;

        public ImportEmployeeServiceTests()
        {
            _factory = new EmployeeDbContextFactoryFixture();
            _service = new EmployeeManager(_factory);

        }
        [Fact()]
        public void ShouldImportSuccessfully_ReturnsIBankInformations()
        {
            EmployeeImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\ACCUDATA_08302022.xls";
           IEnumerable<IBankInformation> actualBankInformations =  importer.StartImport(filename);
            
            _service.Save(actualBankInformations.First());

                Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }
    }
}