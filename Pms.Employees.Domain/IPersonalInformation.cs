using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain
{
    public interface IPersonalInformation
    {
        string EEId { get; set; }
        
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string NameExtension { get; set; }
        
        //string Gender { get; set; }

        string Location { get; set; }
        string Site { get; set; }
        //string PayrollCode { get; set; }
        string BankCategory { get; set; }
        
        //string Pagibig { get; set; }
        //string PhilHealth { get; set; }
        //string SSS { get; set; }
        //string TIN { get; set; }
        DateTime BirthDate { get; set; }
        string BirthDateSetter { set; }
        bool Active { get; set; } 
    }
}
