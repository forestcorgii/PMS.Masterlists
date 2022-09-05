using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain.Exceptions
{
    public class UnknownBankException : Exception
    {
        public string Bank { get; set; }
        public UnknownBankException(string bank)
        {
            Bank= bank;
        }
    }
}
