using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.Domain.Entities.Employees
{
    public interface IActive
    {
        string EEId { get; set; }
        bool Active { get; set; }
    }
}
