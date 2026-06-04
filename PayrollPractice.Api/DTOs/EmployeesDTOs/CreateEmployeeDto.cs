namespace PayrollPractice.Api.DTOs.EmployeesDTOs;

public class CreateEmployeeDto
{
    public required string Name { get; set; }
    public required string CompanyName { get; set; }
    public required decimal HourlyRate { get; set; }
    public required string DepartmentName { get; set; }
    public required DateTime BirthDate { get; set; }
    public required DateTime StartDate { get; set; }
}
