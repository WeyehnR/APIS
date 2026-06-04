using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Models;
namespace PayrollPractice.Api.Context;

public class PayrollPracticeDBContext(DbContextOptions<PayrollPracticeDBContext> options) : DbContext(options)
{
    // DbSet represents a table in the database
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
}
