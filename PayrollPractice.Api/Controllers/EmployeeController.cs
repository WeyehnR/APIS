using Microsoft.AspNetCore.Mvc;
using PayrollPractice.Api.DTOs.EmployeesDTOs;
using PayrollPractice.Api.Contract;


namespace PayrollPractice.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//So we need to inject the PayrollPracticeDbContext into the controller to access the database. We can do this using constructor injection.
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService;


    [HttpPost]
    public async Task<ActionResult> CreateEmployee(CreateEmployeeDto employeeCreateDto)
    {
        try
        {
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeCreateDto);
            return Ok(createdEmployee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}