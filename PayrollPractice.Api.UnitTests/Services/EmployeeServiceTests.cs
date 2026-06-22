using Microsoft.EntityFrameworkCore;
using PayrollPractice.Api.Context;
using PayrollPractice.Api.DTOs.EmployeesDTOs;
using PayrollPractice.Api.Models;
using PayrollPractice.Api.Services;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel, Workers = 0)]

namespace PayrollPractice.Api.UnitTests.Services;

[TestClass]
public class EmployeeServiceTests
{
    private PayrollPracticeDBContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<PayrollPracticeDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new PayrollPracticeDBContext(options);
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_WithValidData_ShouldCreateEmployee()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var department = new Department { Id = 1, Name = "IT", CompanyId = 1 };
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var createDto = new CreateEmployeeDto
        {
            Name = "John Doe",
            HourlyRate = 25.50m,
            DepartmentId = 1,
            BirthDate = new DateTime(1990, 5, 15),
            StartDate = new DateTime(2024, 1, 1)
        };

        // Act
        var result = await service.CreateEmployeeAsync(createDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("John Doe", result.Name);
        Assert.AreEqual(25.50m, result.HourlyRate);
        Assert.AreEqual(1, result.DepartmentId);
        Assert.AreEqual(new DateTime(1990, 5, 15), result.BirthDate);
        Assert.AreEqual(new DateTime(2024, 1, 1), result.StartDate);
#pragma warning disable MSTEST0037 // Use 'Assert.IsGreaterThan' instead of 'Assert.IsTrue'
        Assert.IsTrue(result.Id > 0);
#pragma warning restore MSTEST0037
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_WithNonExistentDepartment_ShouldThrowException()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var createDto = new CreateEmployeeDto
        {
            Name = "Jane Smith",
            HourlyRate = 30.00m,
            DepartmentId = 999, // Non-existent department
            BirthDate = new DateTime(1985, 8, 20),
            StartDate = new DateTime(2024, 1, 1)
        };

        // Act & Assert
        try
        {
            await service.CreateEmployeeAsync(createDto);
            Assert.Fail("Expected exception was not thrown");
        }
        catch (Exception ex)
        {
            Assert.AreEqual("Department with ID 999 does not exist.", ex.Message);
        }
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_ShouldPersistEmployeeToDatabase()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var department = new Department { Id = 1, Name = "HR", CompanyId = 1 };
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var createDto = new CreateEmployeeDto
        {
            Name = "Alice Johnson",
            HourlyRate = 28.75m,
            DepartmentId = 1,
            BirthDate = new DateTime(1992, 3, 10),
            StartDate = new DateTime(2024, 2, 1)
        };

        // Act
        var result = await service.CreateEmployeeAsync(createDto);

        // Assert - Verify the employee was actually saved to the database
        var savedEmployee = await context.Employees.FindAsync(result.Id);
        Assert.IsNotNull(savedEmployee);
        Assert.AreEqual("Alice Johnson", savedEmployee.Name);
        Assert.AreEqual(28.75m, savedEmployee.HourlyRate);
        Assert.AreEqual(1, savedEmployee.DepartmentId);
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_WithMinimumWage_ShouldCreateEmployee()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var department = new Department { Id = 1, Name = "Operations", CompanyId = 1 };
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var createDto = new CreateEmployeeDto
        {
            Name = "Bob Williams",
            HourlyRate = 0.01m, // Minimum possible rate
            DepartmentId = 1,
            BirthDate = new DateTime(2000, 12, 31),
            StartDate = new DateTime(2024, 3, 1)
        };

        // Act
        var result = await service.CreateEmployeeAsync(createDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0.01m, result.HourlyRate);
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_WithHighHourlyRate_ShouldCreateEmployee()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var department = new Department { Id = 1, Name = "Executive", CompanyId = 1 };
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var createDto = new CreateEmployeeDto
        {
            Name = "Carol Martinez",
            HourlyRate = 150.00m, // High hourly rate
            DepartmentId = 1,
            BirthDate = new DateTime(1980, 6, 15),
            StartDate = new DateTime(2024, 1, 15)
        };

        // Act
        var result = await service.CreateEmployeeAsync(createDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(150.00m, result.HourlyRate);
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_WithFutureBirthDate_ShouldCreateEmployee()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var department = new Department { Id = 1, Name = "Finance", CompanyId = 1 };
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var createDto = new CreateEmployeeDto
        {
            Name = "David Lee",
            HourlyRate = 35.00m,
            DepartmentId = 1,
            BirthDate = new DateTime(2030, 1, 1), // Future birth date (edge case)
            StartDate = new DateTime(2024, 4, 1)
        };

        // Act
        var result = await service.CreateEmployeeAsync(createDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(new DateTime(2030, 1, 1), result.BirthDate);
    }

    [TestMethod]
    public async Task CreateEmployeeAsync_WithPastStartDate_ShouldCreateEmployee()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var service = new EmployeeService((Contract.IEmployeeRepository)context);

        var department = new Department { Id = 1, Name = "Marketing", CompanyId = 1 };
        context.Departments.Add(department);
        await context.SaveChangesAsync();

        var createDto = new CreateEmployeeDto
        {
            Name = "Emma Garcia",
            HourlyRate = 32.00m,
            DepartmentId = 1,
            BirthDate = new DateTime(1995, 7, 22),
            StartDate = new DateTime(2020, 1, 1) // Past start date
        };

        // Act
        var result = await service.CreateEmployeeAsync(createDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(new DateTime(2020, 1, 1), result.StartDate);
    }
}
