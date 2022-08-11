using Pms.Employees.Domain;
using Pms.Employees.Persistence;
using Pms.Employees.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.Concrete
{
    public class ManageEmployeeService : IManageEmployeeService
    {
        private EmployeeDbContextFactory _factory;
        public ManageEmployeeService(EmployeeDbContextFactory factory) =>
            _factory = factory;


        public void CreateOrEditAndSave(Employee employee)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();

            if (Context.Employees.Count(ee => ee.EEId == employee.EEId) > 0)
                Context.Update(employee);
            else
                Context.Add(employee);
            Context.SaveChanges();

        }

    }
}
