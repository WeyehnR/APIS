namespace PayrollPractice.Api.DTOs.DepartmentDTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public int EmployeeCount { get; set; }
}