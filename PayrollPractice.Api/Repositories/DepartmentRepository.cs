using PayrollPractice.Api.Context;
using PayrollPractice.Api.Contract;

namespace PayrollPractice.Api.Repositories;

public class DepartmentRepository(PayrollPracticeDBContext context) : IDepartmentRepository
{
    private readonly PayrollPracticeDBContext _context = context;
}
