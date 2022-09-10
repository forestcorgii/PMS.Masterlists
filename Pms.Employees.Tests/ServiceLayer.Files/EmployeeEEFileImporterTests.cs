using Xunit;
using Pms.Employees.ServiceLayer.Files;
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

namespace Pms.Employees.ServiceLayer.Files.Tests
{
    public class EmployeeEEFileImporterTests
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        private IManageEmployeeService _service;

        public EmployeeEEFileImporterTests()
        {
            _factory = new EmployeeDbContextFactoryFixture();
            _service = new EmployeeManager(_factory);
        }

        [Fact()]
        public void ShouldImportEEFile()
        {
            EmployeeEEFileImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\EE DATA_as of 202208.xls";
            IEnumerable<IEEFileInformation> actualBankInformations = importer.StartImport(filename);

            _service.Save(actualBankInformations.Last());

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);

        }
    }
}