using Microsoft.EntityFrameworkCore;
using Pms.Masterlists.Domain.Entities.Employees;
using Pms.Masterlists.Persistence;
using System.Linq;

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



