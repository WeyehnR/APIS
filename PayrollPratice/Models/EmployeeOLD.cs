namespace PayrollPratice.Models;

class EmployeeOLD
{
    public required int Id { get; set; }
    public required string Name { get; set; } = "";
    public required decimal HourlyRate { get; set; }
    public required string DepartmentName { get; set; }

    public string CompanyName { get; set; } = "Microsoft";
    //birth date
    public required DateTime BirthDate { get; set; }

    //start date
    public required DateTime StartDate { get; set; }  
    public required DateTime EndDate { get; set; }

}

/*
 * Behind the scenes, the C# compiler generates a class that looks something like this:
 * 
 * class Employee
 * {
 *      private int _Id;
 *      private string _Name;
 *      private decimal _HourlyRate;
 *      
 *      public int Id { get { return _Id; } set { _Id = value; } }
 *      public string Name { get { return _Name; } set { _Name = value; } }
 *      public decimal HourlyRate { get { return _HourlyRate; } set { _HourlyRate = value; } }
 * }
 */