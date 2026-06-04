using PayrollPratice;

var employee = new Employee { Id = 1, Name = "John Doe", HourlyRate = 15.50m };

Console.WriteLine($"Employee: {employee.Name}");
Console.WriteLine($"ID: {employee.Id}");
Console.WriteLine($"Hourly Rate: ${employee.HourlyRate}");