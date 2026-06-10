// Contract/IEmployeeRepository.cs
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Contract;

public interface IEmployeeRepository
{
    // Read operations
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Employee>> GetAllAsync();

    // Write operations
    Task<Employee> AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);

    // Query operations
    Task<bool> ExistsAsync(int id);
    Task<bool> DepartmentExistsAsync(int departmentId);

    // Save
    Task<int> SaveChangesAsync();
}
