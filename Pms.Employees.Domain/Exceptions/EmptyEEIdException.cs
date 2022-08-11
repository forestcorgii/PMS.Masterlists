using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain.Exceptions
{
    public class EmptyEEIdException : Exception
    {
        public string EEId { get; set; }
        public EmptyEEIdException(string eeId)
        {
            EEId = eeId;
        }
    }
}
