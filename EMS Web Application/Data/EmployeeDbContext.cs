using EMS_Web_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_Web_Application.Data
{
    public class EmployeeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder); 
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)      // configuring the table using fluent API
        {
            {
                modelBuilder.Entity<Employee>()
                .HasOne<Department>(s => s.DepartmentId)
                .WithOne(ad => ad.Employee)
                .HasForeignKey<Department>(ad => ad.DepartmentId);

                base.OnModelCreating(modelBuilder);
            }

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
