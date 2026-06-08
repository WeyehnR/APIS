using PayrollPractice.Api.DTOs.EmployeesDTOs;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Contract;

public interface IEmployeeService
{
    public Task<Employee> CreateEmployeeAsync(CreateEmployeeDto employeeCreateDto);
    public Task<Employee?> GetEmployeeByIdAsync(int employeeId);
    public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    public Task<Employee> UpdateEmployeeAsync(Employee employeeToUpdateDto);
    public Task<Employee> DeleteEmployeeAsync(Employee employeeToDeleteDto);
}