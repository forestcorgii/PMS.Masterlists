using Payroll.Employees.Domain;
using Payroll.Employees.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Employees.ServiceLayer.Concrete
{
    public class SaveEmployeeService
    {
        private EmployeeDbContext Context;
        public SaveEmployeeService(EmployeeDbContext context) =>
            Context = context;

        public void CreateOrEdit(Employee employee)
        {
            if (Context.Employees.Count(ee => ee.EEId == employee.EEId) > 0)
                Context.Entry(employee).CurrentValues.SetValues(employee);
            else
                Context.Add(employee);
        }

        public void CreateOrEditAndSave(Employee employee)
        {
            CreateOrEdit(employee);
            Context.SaveChanges();
        }

    }
}
