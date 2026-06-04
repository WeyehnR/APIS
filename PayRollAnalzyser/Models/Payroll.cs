namespace PayRollAnalzyser.Models;

public class Payroll
{
    private decimal _hoursWorked;
    private decimal _hourlyRate;

    //need a payroll id to link to distigush between different payroll records (possibly on the same day)
    public int Id { get; init; }

    //also need an employee id to link to employee
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public decimal HoursWorked
    {
        get => _hoursWorked;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(HoursWorked), "HoursWorked cannot be negative.");
            }
            else
            { 
                _hoursWorked = value;
            }
        }
    }
    public decimal HourlyRate
    {
        get => _hourlyRate;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(HourlyRate), "HourlyRate cannot be negative.");
            }
            else
            {
                _hourlyRate = value;
            }
        }
    }

    public decimal TotalGrossPay => CalculateSalary();
    public decimal CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }
}
