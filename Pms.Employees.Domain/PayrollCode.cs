using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pms.Employees.Domain.Enums;

namespace Pms.Employees.Domain
{
    public class PayrollCode
    {
        public string PayrollCodeId { get; set; }
        public string Name { get; set; }

        public string CompanyId { get; set; }
        //public CompanyView Company { get; set; }

        public string Site { get; set; }

        public PayrollRegisterTypeChoices Process { get; set; }

        public string GenerateId() => $"{Site[0]}-{Name}";
    }
}
