namespace PayrollPractice.Api.DTOs.EmployeesDTOs;

public class EmployeeDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal HourlyRate { get; set; }
    public required string DepartmentName { get; set; }
    public required int DepartmentId { get; set; }
    public required DateTime BirthDate { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
