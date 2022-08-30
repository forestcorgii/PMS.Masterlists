using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain
{
    public interface IBankInformation
    {
        string EEId { get; set; }
        string BankName { get; set; }
        string CardNumber { get; set; }
        string AccountNumber { get; set; }
        string PayrollCode { get; set; }
    }
}
