using PayRollAnalzyser.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// In Program.cs, before builder.Build()
builder.Services.AddDbContext<PayrollContextGateway>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//create a scope to access the service provider (using IServiceProvider) and get the DbContext instance

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PayrollContextGateway>();
    //assume that the employee and payroll tables are created and empty, we can seed some data for testing
    if (!context.Employees.Any())
    {
        // If that condition is true,
        // what is the next logical step our code should take to start adding those "seed" employees to the database?
        // The next logical step would be to create a list of employee objects with the necessary properties filled in,
        // and then add those objects to the Employees DbSet of the context, followed by saving the changes to the database.
       var alice = new Employee { 
           Id = 1, 
           FirstName = "Alice", 
           LastName = "Smith", 
           Payrolls =
           [
               new() { HoursWorked = 40, HourlyRate = 25 }
           ]
       };

    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
