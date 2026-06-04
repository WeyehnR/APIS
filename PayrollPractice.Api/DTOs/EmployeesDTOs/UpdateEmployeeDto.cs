namespace PayrollPractice.Api.DTOs.EmployeesDTOs;

public class UpdateEmployeeDto
{
    public string? Name { get; set; }
    public string? CompanyName { get; set; }
    public decimal? HourlyRate { get; set; }
    public string? DepartmentName { get; set; }
    public DateTime? EndDate { get; set; }
}
