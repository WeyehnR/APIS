using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.DTOs.CompanyDTO;

public class CreateCompanyDto
{
    [Required]
    [StringLength(200)]
    public required string CompanyName { get; set; }
}