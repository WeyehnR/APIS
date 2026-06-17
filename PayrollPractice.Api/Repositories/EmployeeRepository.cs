using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Context;
using PayrollPractice.Api.Contract;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Repositories;

public class EmployeeRepository(PayrollPracticeDBContext context) : IEmployeeRepository
{
    // Read operations
    public async Task<Employee?> GetByIdAsync(int id)
        => await context.Employees.FindAsync(id);

    public async Task<Employee?> GetByIdWithDetailsAsync(int id)
        => await context.Employees
            .Include(e => e.Department)
                .ThenInclude(d => d!.Company)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<Employee>> GetAllAsync()
        => await context.Employees.ToListAsync();

    // Write operations
    public async Task<Employee> AddAsync(Employee employee)
    {
        await context.Employees.AddAsync(employee);
        return employee;
    }

    public Task UpdateAsync(Employee employee)
    {
        context.Employees.Update(employee);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Employee employee)
    {
        context.Employees.Remove(employee);
        return Task.CompletedTask;
    }

    // Query helper operations
    public async Task<bool> ExistsAsync(int id)
        => await context.Employees.AnyAsync(e => e.Id == id);

    public async Task<bool> DepartmentExistsAsync(int departmentId)
        => await context.Departments.AnyAsync(d => d.Id == departmentId);

    // Save
    public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();
}