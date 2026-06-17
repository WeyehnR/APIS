using Microsoft.AspNetCore.Mvc;
using PayrollPractice.Api.Contract;
using PayrollPractice.Api.DTOs.EmployeesDTOs;

namespace PayrollPractice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createDto)
    {
        try
        {
            // 1. Call the service layer to validate and process business logic
            var createdEmployeeDto = await employeeService.CreateEmployeeAsync(createDto);

            // 2. Return HTTP 201 Created with a pointer to where the resource lives
            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = createdEmployeeDto.Id },
                createdEmployeeDto
            );
        }
        catch (ArgumentException ex) // Catching validation issues (e.g., Department doesn't exist)
        {
            // Return HTTP 400 Bad Request with the validation message
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception)
        {
            // Return HTTP 500 Internal Server Error for unhandled crashes
            return StatusCode(500, new { message = "An error occurred while processing your request." });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        // Placeholder GET endpoint so CreatedAtAction has a valid action name to reference
        return Ok(new { id, message = "GET endpoint placeholder" });
    }
}