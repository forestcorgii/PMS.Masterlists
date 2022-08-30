using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain
{
    public interface IGovernmentInformation
    {
        string EEId { get; set; }

        string Pagibig { get; set; }
        string PhilHealth { get; set; }
        string SSS { get; set; }
        string TIN { get; set; }
        DateTime BirthDate { get; set; }
        string BirthDateString { set; }
    }
}
