using AtaTexnologiyadan.Entityes.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AtaTexnologiyadan.Persistence
{
    public class MainDataDBContext : DbContext
    {
        public MainDataDBContext(DbContextOptions<MainDataDBContext> options) : base(options)
        {
        }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}