using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain.Entities.Employees
{
    public interface IHRMSInformation
    {
        string EEId { get; set; }
        string Location { get; set; }
        string JobCode { get; set; }
        
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        
    }
}
