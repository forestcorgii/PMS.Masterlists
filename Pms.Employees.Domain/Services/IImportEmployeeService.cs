using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain.Services
{
    public interface IImportEmployeeService
    {
        IEnumerable<IBankInformation> StartImport(string fileName,string bankName);

    }
}
