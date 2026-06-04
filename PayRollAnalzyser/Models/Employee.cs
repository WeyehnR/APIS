namespace PayRollAnalzyser.Models;

public class Employee
{
    public int Id { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    //an employee can have multiple payroll records, so we need a collection to hold those records
    public ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

}