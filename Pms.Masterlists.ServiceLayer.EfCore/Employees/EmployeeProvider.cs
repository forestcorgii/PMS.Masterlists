using Microsoft.EntityFrameworkCore;
using Pms.Masterlists.Domain;
using Pms.Masterlists.Persistence;
using Pms.Masterlists.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.ServiceLayer.EfCore
{
    public class EmployeeProvider 
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        public EmployeeProvider(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        public IQueryable<Employee> GetEmployees()
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Employees.AsNoTracking();
        }
 
        public bool EmployeeExists(string eeId)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Employees.Any(ee => ee.EEId == eeId);
        }

        public Employee FindEmployee(string eeId)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Employees.Find(eeId);
        }
    }
}



