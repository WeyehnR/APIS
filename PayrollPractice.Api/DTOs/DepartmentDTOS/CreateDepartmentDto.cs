using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.DTOs.DepartmentDTOs;

public class CreateDepartmentDto
{
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    public int CompanyId { get; set; }
}