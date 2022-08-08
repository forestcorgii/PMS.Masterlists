using Pms.Employees.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.HRMS
{
    public interface IEmployeeFinder
    {
        Task<Employee> GetEmployeeAsync(string EEId, string site = "MANILA");
    }
}
