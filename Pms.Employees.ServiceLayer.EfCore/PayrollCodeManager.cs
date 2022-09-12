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
    public class PayrollCodeManager
    {
        private IDbContextFactory<EmployeeDbContext> _factory;
        public PayrollCodeManager(IDbContextFactory<EmployeeDbContext> factory) =>
            _factory = factory;

        public IQueryable<PayrollCode> GetPayrollCodes()
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            return Context.PayrollCodes.AsNoTracking();
        }




        public void SavePayrollCode(PayrollCode payrollCode)
        {
            EmployeeDbContext Context = _factory.CreateDbContext();
            if (Context.PayrollCodes.Any(pc => pc.PayrollCodeId == payrollCode.PayrollCodeId))
                Context.Update(payrollCode);
            else
                Context.Add(payrollCode);

            Context.SaveChanges();
        }

    }
}
