using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.Models;

public class Company
{
    [Required]
    public int Id { get; set; } // Changed from string to int

    [Required]
    public required string CompanyName { get; set; }

    // Navigation property - all departments in this company
    public List<Department> Departments { get; set; } = [];

    // REMOVED: Direct Employees navigation
    // Access employees through Departments
}