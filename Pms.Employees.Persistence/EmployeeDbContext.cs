using Microsoft.EntityFrameworkCore;


using Pms.Employees.Domain;
using System;

namespace Pms.Employees.Persistence
{
    public class EmployeeDbContext : DbContext
    {
         public DbSet<Employee> Employees => Set<Employee>();
         
        private readonly string ConnectionString = "server=localhost;database=payroll2_efdb;user=root;password=Soft1234;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL(ConnectionString, options =>
                options.MigrationsHistoryTable("EmployeesMigrationHistoryName"))
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
