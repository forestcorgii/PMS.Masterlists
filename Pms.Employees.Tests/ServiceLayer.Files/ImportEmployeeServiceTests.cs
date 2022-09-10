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
            EmployeeBankInformationImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\LBP BP6A.xls";
            IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

            IBankInformation actualBankInformation = actualBankInformations.First();

            Assert.Equal(Enums.BankChoices.LBP, actualBankInformation.Bank);
            
            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }

        [Fact()]
        public void ShouldImportCHKSuccessfully_ReturnsIBankInformations()
        {
            EmployeeBankInformationImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\CHK.xls";
            IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

            IBankInformation actualBankInformation = actualBankInformations.First();
            Assert.Equal(Enums.BankChoices.CHK, actualBankInformation.Bank);

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }

        [Fact()]
        public void ShouldImportLBPSuccessfully_ReturnsIBankInformations()
        {
            EmployeeBankInformationImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\LBP.xls";
            IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

            IBankInformation actualBankInformation = actualBankInformations.First();
            Assert.Equal(Enums.BankChoices.LBP, actualBankInformation.Bank);
            Assert.NotEmpty(actualBankInformation.AccountNumber);
            Assert.NotEmpty(actualBankInformation.CardNumber);

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }

        [Fact()]
        public void ShouldImportCBCSuccessfully_ReturnsIBankInformations()
        {
            EmployeeBankInformationImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\CBC.xls";
            IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

            IBankInformation actualBankInformation = actualBankInformations.First();
            Assert.Equal(Enums.BankChoices.CBC, actualBankInformation.Bank);
            Assert.NotEmpty(actualBankInformation.AccountNumber);

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }

        [Fact()]
        public void ShouldImportMPALOSuccessfully_ReturnsIBankInformations()
        {
            EmployeeBankInformationImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\MPALO.xls";
            IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

            IBankInformation actualBankInformation = actualBankInformations.First();
            Assert.Equal(Enums.BankChoices.MPALO, actualBankInformation.Bank);
            Assert.NotEmpty(actualBankInformation.AccountNumber);

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }

        [Fact()]
        public void ShouldImportMTACSuccessfully_ReturnsIBankInformations()
        {
            EmployeeBankInformationImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\MTAC.xls";
            IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

            IBankInformation actualBankInformation = actualBankInformations.First();
            Assert.Equal(Enums.BankChoices.MTAC, actualBankInformation.Bank);
            Assert.NotEmpty(actualBankInformation.AccountNumber);

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }
    }
}