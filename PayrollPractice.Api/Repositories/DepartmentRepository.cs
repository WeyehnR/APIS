using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Context;
using PayrollPractice.Api.Contract;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Repositories;

public class DepartmentRepository(PayrollPracticeDBContext context) : IDepartmentRepository
{
    // Read operations
    public async Task<Department?> GetByIdAsync(int id)
        => await context.Departments.FindAsync(id);

    public async Task<Department?> GetByIdWithDetailsAsync(int id)
        => await context.Departments
            .Include(d => d.Company)      // Eagerly loads the parent Company
            .Include(d => d.Employees)    // Eagerly loads all Employees in this department
            .FirstOrDefaultAsync(d => d.Id == id);

    public async Task<IEnumerable<Department>> GetAllAsync()
        => await context.Departments.ToListAsync();

    public async Task<IEnumerable<Department>> GetDepartmentsByCompanyAsync(int companyId)
        => await context.Departments
            .Where(d => d.CompanyId == companyId)
            .ToListAsync();

    // Write operations
    public async Task<Department> AddAsync(Department department)
    {
        await context.Departments.AddAsync(department);
        return department;
    }

    public Task UpdateAsync(Department department)
    {
        context.Departments.Update(department);
        return Task.CompletedTask; // Instantly returns a completed Task safely
    }

    public Task DeleteAsync(Department department)
    {
        context.Departments.Remove(department);
        return Task.CompletedTask; // Instantly returns a completed Task safely
    }

    // Query helper operations
    public async Task<bool> ExistsAsync(int id)
        => await context.Departments.AnyAsync(d => d.Id == id);

    public async Task<bool> CompanyExistsAsync(int companyId)
        => await context.Companies.AnyAsync(c => c.Id == companyId);

    // Save
    public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();
}