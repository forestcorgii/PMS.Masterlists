using Xunit;
using Pms.Masterlists.ServiceLayer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms.Masterlists.Domain.Entities.Employees;

namespace Pms.Masterlists.ServiceLayer.Files.Tests
{
    public class Master_File_Importer_is_valid
    {
        [Fact()]
        public void if_it_does_not_throw_exception()
        {
            MasterFileImporter importer = new();

            string filename = $@"{AppDomain.CurrentDomain.BaseDirectory}\TESTDATA\MASTER FILE.xls";
            IEnumerable<IMasterFileInformation> masterFileInformations = importer.StartImport(filename);

            

            Assert.NotNull(masterFileInformations);
            Assert.NotEmpty(masterFileInformations);
        }
    }
}