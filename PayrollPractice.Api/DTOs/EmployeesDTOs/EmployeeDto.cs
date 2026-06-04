namespace PayrollPractice.Api.DTOs.EmployeesDTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required decimal HourlyRate { get; set; }

    // Department info
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }  // Optional - for display

    // Company info
    public int CompanyId { get; set; }           
    public string? CompanyName { get; set; }     // Optional - for display

    public required DateTime BirthDate { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}