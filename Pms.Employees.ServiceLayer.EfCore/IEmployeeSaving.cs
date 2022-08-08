using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.EfCore
{
    public interface IEmployeeSaving
    {
        void CreateOrEdit(Employee employee);
        void CreateOrEditAndSave(Employee employee);
    }
}
