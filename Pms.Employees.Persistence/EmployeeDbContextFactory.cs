using Microsoft.EntityFrameworkCore;


using Pms.Employees.Domain;
using System;

namespace Pms.Employees.Persistence
{
    public class EmployeeDbContextFactory : IDbContextFactory<EmployeeDbContext>
    {
        private readonly string _connectionString = "server=localhost;database=payroll2_efdb;user=root;password=Soft1234;";
        public EmployeeDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public EmployeeDbContext CreateDbContext()
        {
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder()
                .UseMySQL(_connectionString,
                    options => options.MigrationsHistoryTable("EmployeesMigrationHistoryName")
                )
                .Options;

            return new EmployeeDbContext(dbContextOptions);
        }
    }
}
