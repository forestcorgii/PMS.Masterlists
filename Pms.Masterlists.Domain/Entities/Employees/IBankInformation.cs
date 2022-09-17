using Pms.Masterlists.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain
{
    public interface IBankInformation
    {
        string EEId { get; set; }
        string CardNumber { get; set; }
        string AccountNumber { get; set; }
        string PayrollCode { get; set; }

        string BankSetter { set; }
        BankChoices Bank { get; set; }
    }
}
