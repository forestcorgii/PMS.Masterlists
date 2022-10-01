using Xunit;
using System;
using System.Collections.Generic;
using Pms.Masterlists.Domain.Entities.Employees;

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
        public class An_extracted_employees_from_L_EE_DATA_import_can_be_saved
        {
            [Fact()]
            public void if_this_does_not_throw_an_exception()
            {
                EmployeeEEDataImporter importer = new();

                string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\L EE DATA 2209.xls";
                IEnumerable<IEEDataInformation> actualBankInformations = importer.StartImport(filename);

                foreach (Employee actualBankInformation in actualBankInformations)
                    actualBankInformation.ValidateBankInformation();

                Assert.NotNull(actualBankInformations);
                Assert.NotEmpty(actualBankInformations);

            }
        }

    }
}