using EmployeeManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) 
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=EmployeeDb.db");
        }

    }
}
