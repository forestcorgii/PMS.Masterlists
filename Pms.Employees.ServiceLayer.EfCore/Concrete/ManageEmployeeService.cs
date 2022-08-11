using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Domain.Exceptions;
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
        private IDbContextFactory<EmployeeDbContext> _factory;

        public ManageEmployeeService(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        private void Validate(Employee employee)
        {
            if (employee.EEId == "")
                throw new EmptyEEIdException(employee.EEId);
        }

        public void CreateOrEditAndSave(Employee employee)
        {
            Validate(employee);

            EmployeeDbContext Context = _factory.CreateDbContext();

            if (Context.Employees.Count(ee => ee.EEId == employee.EEId) > 0)
                Context.Update(employee);
            else
                Context.Add(employee);
            Context.SaveChanges();

        }

    }
}
