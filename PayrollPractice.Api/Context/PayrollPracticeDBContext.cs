using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Context;

public class PayrollPracticeDBContext(DbContextOptions<PayrollPracticeDBContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fix the decimal precision warning
        modelBuilder.Entity<Employee>()
            .Property(e => e.HourlyRate)
            .HasPrecision(18, 2);
    }
}