using Pms.Masterlists.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain
{
    public class PayrollCode
    {
        public string PayrollCodeId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string CompanyId { get; set; } = string.Empty;
        
        public string Site { get; set; } = string.Empty;

        public PayrollRegisterTypes Process { get; set; }


        public PayrollCode() { }
        public PayrollCode(string name, string site)
        {
            Name = name;
            Site = site;

            PayrollCodeId = GenerateId(this);
        }



        public static string GenerateId(PayrollCode payrollCode) => $"{payrollCode.Site[0]}-{payrollCode.Name}";

        public override string ToString()
        {
            return PayrollCodeId;
        }
    }
}
