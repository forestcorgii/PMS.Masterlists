using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain.Entities.Employees
{
    public interface IMasterFileInformation
    {
        public string EEId { get; set; }
        public string JobCode { get; set; }
    }
}
