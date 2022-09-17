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
        public string PayrollCodeId { get; set; }
        public string Name { get; set; }

        public string CompanyId { get; set; }
        //public CompanyView Company { get; set; }

        public string Site { get; set; }

        public PayrollRegisterTypes Process { get; set; }



        public PayrollCode() { }

        public PayrollCode(string name, string site)
        {
            Name = name;
            Site = site;
            PayrollCodeId = GenerateId();
        }



        public string GenerateId() => $"{Site[0]}-{Name}";

        public override string ToString()
        {
            return PayrollCodeId;
        }
    }
}
