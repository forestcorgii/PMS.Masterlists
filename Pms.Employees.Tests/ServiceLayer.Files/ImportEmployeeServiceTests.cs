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

namespace Pms.Employees.Files.Tests
{
    public class ImportEmployeeServiceTests
    {
        [Fact()]
        public void ShouldImportSuccessfully_ReturnsIBankInformations()
        {
            ImportEmployeeService importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\TEMPLATE UPLOAD NEW EE-ATM_20220830-updated.xls";
           IEnumerable<IBankInformation> actualBankInformations =  importer.StartImport(filename, "CHB");

            Assert.NotNull(actualBankInformations);
            Assert.NotEmpty(actualBankInformations);
        }
    }
}