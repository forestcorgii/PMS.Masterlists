using Xunit;
using System;
using System.Collections.Generic;
using Pms.Masterlists.ServiceLayer.Files;
using Pms.Masterlists.Domain.Entities.Employees;

namespace Pms.Masterlists.Files.Tests
{
    public class EmployeeBankInformationFileImporterTests
    {

        public class An_extracted_employees_from_bank_information_import_can_be_saved
        {
            [Fact()]
            public void if_this_does_not_throw_an_exception()
            {
                EmployeeBankInformationImporter importer = new();

                string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\BANK INFORMATION SAMPLE 2209.xls";
                IEnumerable<IBankInformation> actualBankInformations = importer.StartImport(filename);

                foreach (Employee actualBankInformation in actualBankInformations)
                    actualBankInformation.ValidateBankInformation();


                Assert.NotNull(actualBankInformations);
                Assert.NotEmpty(actualBankInformations);
            }
        }
    }
}