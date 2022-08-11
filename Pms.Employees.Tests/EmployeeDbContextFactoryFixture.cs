using Microsoft.EntityFrameworkCore;
using Pms.Employees.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.Tests
{
    public class EmployeeDbContextFactoryFixture : IDbContextFactory
    {
        private const string ConnectionString = "server=localhost;database=payroll3Test_efdb;user=root;password=Soft1234;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public EmployeeDbContextFactoryFixture()
        {
            CreateFactory();
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateDbContext())
                    {
                        context.Database.Migrate();
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        //context.AddRange( );
                        //context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public EmployeeDbContextFactory Factory;
        public void CreateFactory()
            => Factory = new EmployeeDbContextFactory(ConnectionString);

        public EmployeeDbContext CreateDbContext()
            => Factory.CreateDbContext();
    }
}
