using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.DTOs.EmployeesDTOs;

public class CreateEmployeeDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public required decimal HourlyRate { get; set; }

    [Required]
    public required int DepartmentId { get; set; }  

    [Required]
    public required DateTime BirthDate { get; set; }

    [Required]
    public required DateTime StartDate { get; set; }
}