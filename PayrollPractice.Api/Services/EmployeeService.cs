using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Context;
using PayrollPractice.Api.Contract;
using PayrollPractice.Api.DTOs.EmployeesDTOs;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDto employeeCreateDto)
    {
        var departmentExists = await _employeeRepository.DepartmentExistsAsync(employeeCreateDto.DepartmentId);
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

        await _employeeRepository.AddAsync(newEmployee);
        await _employeeRepository.SaveChangesAsync();
        return newEmployee;
    }
    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
    {
        return await _employeeRepository.GetByIdWithDetailsAsync(employeeId);
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
