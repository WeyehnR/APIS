using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.Models;

public class Employee
{
    [Required]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required decimal HourlyRate { get; set; }

    // Foreign key to Department
    [Required]
    public int DepartmentId { get; set; }

    // Navigation property - the department this employee belongs to
    public Department? Department { get; set; }

    // Foreign key to Company
    [Required]
    public int CompanyId { get; set; }

    // Navigation property - the company this employee belongs to
    public Company? Company { get; set; }

    [Required]
    public required DateTime BirthDate { get; set; }

    [Required]
    public required DateTime StartDate { get; set; }

    [Required]
    public required DateTime EndDate { get; set; }
}