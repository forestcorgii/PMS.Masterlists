using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pms.Employees.Domain;
using System;

namespace Pms.Employees.Persistence
{
    public class EmployeeDbContextFactory : IDbContextFactory<EmployeeDbContext>,IDesignTimeDbContextFactory<EmployeeDbContext>
    {
        private readonly string _connectionString;
        public EmployeeDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public EmployeeDbContextFactory()
        {
            _connectionString = "server=localhost;database=payroll3Test_efdb;user=root;password=Soft1234;";
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

        public EmployeeDbContext CreateDbContext(string[] args) => CreateDbContext();
    }
}
