using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.DTOs.CompanyDTO;

public class UpdateCompanyDto
{
    [StringLength(200)]
    public string? CompanyName { get; set; }
}