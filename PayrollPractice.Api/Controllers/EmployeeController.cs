using Microsoft.AspNetCore.Mvc;
using PayrollPractice.Api.DTOs.EmployeesDTOs;

namespace PayrollPractice.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    // Mock data - temporary until we add database access
    private static readonly List<EmployeeDto> _employees =
    [
        new EmployeeDto
        {
            Id = 1,
            Name = "John Doe",
            CompanyId = 1,                    // ✅ Changed from CompanyName
            CompanyName = "Microsoft",        // ✅ This is now optional/display only
            HourlyRate = 50.00m,
            DepartmentId = 1,
            DepartmentName = "Engineering",   // ✅ This is now optional/display only
            BirthDate = new DateTime(1990, 5, 15),
            StartDate = new DateTime(2020, 1, 10),
            EndDate = null
        },
        new EmployeeDto
        {
            Id = 2,
            Name = "Jane Smith",
            CompanyId = 1,                    // ✅ Changed from CompanyName
            CompanyName = "Microsoft",        // ✅ This is now optional/display only
            HourlyRate = 55.00m,
            DepartmentId = 2,
            DepartmentName = "Marketing",     // ✅ This is now optional/display only
            BirthDate = new DateTime(1988, 8, 22),
            StartDate = new DateTime(2019, 3, 15),
            EndDate = null
        }
    ];

    // GET: api/employee
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
    {
        return Ok(_employees);
    }

    // GET: api/employee/{id}
    [HttpGet("{id}")]
    public ActionResult<EmployeeDto> GetEmployeeById(int id)
    {
        var employee = _employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    // Add other methods as needed...
}