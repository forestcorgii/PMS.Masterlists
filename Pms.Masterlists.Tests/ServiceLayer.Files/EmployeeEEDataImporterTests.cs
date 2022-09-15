using Xunit;
using Pms.Masterlists.ServiceLayer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pms.Masterlists.Persistence;
using Pms.Masterlists.Tests;
using Pms.Masterlists.Domain;

namespace Pms.Masterlists.ServiceLayer.Files.Tests
{
    public class EmployeeEEDataImporterTests
    {
        public class An_extracted_employees_from_EE_DATA_import_can_be_saved
        {
            [Fact()]
            public void if_this_does_not_throw_an_exception()
            {
                EmployeeEEDataImporter importer = new();

                string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\EE DATA 2209.xls";
                IEnumerable<IEEDataInformation> actualBankInformations = importer.StartImport(filename);

                foreach (Employee actualBankInformation in actualBankInformations)
                    actualBankInformation.ValidateBankInformation();

                Assert.NotNull(actualBankInformations);
                Assert.NotEmpty(actualBankInformations);

            }
        }

    }
}