using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain
{
    public interface IGeneralInformation
    {
        string EEId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Fullname { get; }
        string Location { get; set; }
        string Site { get; set; }
        string PayrollCode { get; set; }
        string BankCategory { get; set; }
        string Pagibig { get; set; }
        string PhilHealth { get; set; }
        string SSS { get; set; }
        string TIN { get; set; }
        DateTime BirthDate { get; set; }
        string BirthDateString { set; }
        bool Active { get; set; }
        DateTime DateModified { get; set; }
        DateTime DateCreated { get; set; }
    }
}
