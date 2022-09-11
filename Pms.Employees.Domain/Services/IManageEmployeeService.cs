using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain.Services
{
    public interface IManageEmployeeService
    {
        void Save(IPersonalInformation employee);
        void Save(IEEDataInformation employee);
        void Save(IBankInformation employee);
        void Save(IGovernmentInformation employee);
    }
}
