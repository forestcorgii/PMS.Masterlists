using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain.Entities.Employees
{
    public interface IPersonalInformation
    {
        string EEId { get; set; }
        
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string NameExtension { get; set; }
        
        string Location { get; set; }
        string Site { get; set; }
        
        DateTime BirthDate { get; set; }
        string BirthDateSetter { set; }
        bool Active { get; set; } 
    }
}
