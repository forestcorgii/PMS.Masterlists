using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Domain.Exceptions
{
    public class InvalidEmployeeFieldValueException : Exception
    {
        public string EEId { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public InvalidEmployeeFieldValueException(string field, string value, string eeId, string remarks = "Kaya mo yan.")
            : base($"'{value}' is not a valid value for field {field} found in Employee {eeId}. {remarks}")
        {
            Field = field;
            Value = value;
            EEId = eeId;
        }
    }
}
