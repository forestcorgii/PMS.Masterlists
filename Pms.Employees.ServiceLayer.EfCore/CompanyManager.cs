using Microsoft.EntityFrameworkCore;
using Pms.Employees.Domain;
using Pms.Employees.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.EfCore
{
    public class CompanyManager
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        public CompanyManager(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        public IEnumerable<Company> GetAllCompanies()
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.Companies.ToList();
        }


        public void SaveCompany(Company company)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            if (Context.Companies.Any(pc => pc.CompanyId == company.CompanyId))
                Context.Update(company);
            else
                Context.Add(company);

            Context.SaveChanges();
        }
    }
}
