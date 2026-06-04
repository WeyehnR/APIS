using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.DTOs.DepartmentDTOs;

public class UpdateDepartmentDto
{
    [StringLength(100)]
    public string? Name { get; set; }

    public int? CompanyId { get; set; }
}