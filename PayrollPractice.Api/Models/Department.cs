using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.Models;

public class Department
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    // Foreign key to Company
    [Required]
    public int CompanyId { get; set; }

    // Navigation property - the company this department belongs to
    public Company? Company { get; set; }

    // Navigation property - all employees in this department
    public List<Employee> Employees { get; set; } = [];
}