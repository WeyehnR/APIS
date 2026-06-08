using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Context;
using PayrollPractice.Api.Contract;
using PayrollPractice.Api.DTOs.EmployeesDTOs;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Services;

public class EmployeeService(PayrollPracticeDBContext context) : IEmployeeService
{
    private readonly PayrollPracticeDBContext _context = context;

    public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDto employeeCreateDto)
    {
        var departmentExists = _context.Departments.Any(d => d.Id == employeeCreateDto.DepartmentId);
        if (!departmentExists)
        {
            throw new Exception($"Department with ID {employeeCreateDto.DepartmentId} does not exist.");
        }

        var newEmployee = new Employee
        {
            Name = employeeCreateDto.Name,
            HourlyRate = employeeCreateDto.HourlyRate,
            DepartmentId = employeeCreateDto.DepartmentId,
            BirthDate = employeeCreateDto.BirthDate,
            StartDate = employeeCreateDto.StartDate
        };

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return newEmployee;
    }
    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
    {
        return await _context.Employees
            .Include(e => e.Department)           // Load the department
                .ThenInclude(d => d != null ? d.Company : null)      // Load the company through department
            .FirstOrDefaultAsync(e => e.Id == employeeId);  // ✅ Execute the query!
    }

    public Task<Employee> DeleteEmployeeAsync(Employee employeeToDeleteDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }


    public Task<Employee> UpdateEmployeeAsync(Employee employeeToUpdateDto)
    {
        throw new NotImplementedException();
    }
}
