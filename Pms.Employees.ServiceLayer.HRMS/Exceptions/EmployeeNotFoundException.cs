using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.HRMS.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public string EEId { get; set; }
        public EmployeeNotFoundException(string eeId)
        {
            EEId = eeId;
        }
    }
}
