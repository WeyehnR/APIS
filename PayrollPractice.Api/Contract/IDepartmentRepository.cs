using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Contract;

public interface IDepartmentRepository
{
    // Read operations
    Task<Department?> GetByIdAsync(int id);
    Task<Department?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Department>> GetAllAsync();
    Task<IEnumerable<Department>> GetDepartmentsByCompanyAsync(int companyId);

    // Write operations
    Task<Department> AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Department department);

    // Query operations
    Task<bool> ExistsAsync(int id);
    Task<bool> CompanyExistsAsync(int companyId); // Validates the parent company exists

    // Save
    Task<int> SaveChangesAsync();
}