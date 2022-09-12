using Microsoft.EntityFrameworkCore;


using Pms.Employees.Domain;
using System;

namespace Pms.Employees.Persistence
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<CompanyView> Companies => Set<CompanyView>();
        public DbSet<PayrollCode> PayrollCodes => Set<PayrollCode>();

        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        //    optionsBuilder.UseMySQL(ConnectionString, options =>
        //        options.MigrationsHistoryTable("EmployeesMigrationHistoryName"))
        //        .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new PayrollCodeConfiguration());
        }
    }
}
