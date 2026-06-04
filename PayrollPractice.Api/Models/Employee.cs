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

    // REMOVED: CompanyId and Company navigation
    // Employees access Company through Department.Company

    [Required]
    public required DateTime BirthDate { get; set; }

    [Required]
    public required DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}