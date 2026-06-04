using System.ComponentModel.DataAnnotations;

namespace PayrollPractice.Api.Models;

class Employee
{
    //this id is the primary key for the employee - it uniquely identifies the employee in the database
    [Required]
    public required int Id { get; set; }
    [Required]
    public required string Name { get; set; } = "";
    [Required]  
    public required decimal HourlyRate { get; set; }
    [Required]
    public required string DepartmentName { get; set; }

    //employee id to link employee to department -ie employee belongs to the department
    //department id is a foreign key that links the employee to the department
    [Required]
    public required int DepartmentId { get; set; }
    
    [Required]
    public required string CompanyName { get; set; } = "Microsoft";

    //company id to link employee to company
    //employee id is a foreign key that links the employee to the company
    [Required]
    public required int CompanyId { get; set; }
    //birth date
    [Required]
    public required DateTime BirthDate { get; set; }
    //start date
    [Required]
    public required DateTime StartDate { get; set; }  
    [Required]
    public required DateTime EndDate { get; set; }

}