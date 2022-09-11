using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain
{
    public interface IEEDataInformation
    {
        string EEId { get; set; }
        
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string NameExtension { get; set; }
        
        string Gender { get; set; }

        string Pagibig { get; set; }
        string PhilHealth { get; set; }
        string SSS { get; set; }
        string TIN { get; set; }
        DateTime BirthDate { get; set; }
        string BirthDateSetter { set; }
    }
}
