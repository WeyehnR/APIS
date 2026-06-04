namespace PayrollPractice.Api.DTOs.CompanyDTO;

public class CompanyDto
{
    public int Id { get; set; }
    public required string CompanyName { get; set; }
    public int DepartmentCount { get; set; }
    public int EmployeeCount { get; set; }
    public List<int> DepartmentIds { get; set; } = [];
    public List<int> EmployeeIds { get; set; } = [];
}