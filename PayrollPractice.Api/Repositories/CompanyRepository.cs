using PayrollPractice.Api.Context;
using PayrollPractice.Api.Contract;
using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Repositories;

public class CompanyRepository(PayrollPracticeDBContext context) : ICompanyRepository
{
    private readonly PayrollPracticeDBContext _context = context;
    public Task AddAsync(Company company)
    {
        throw new NotImplementedException();
    }

    public void Delete(Company company)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Company?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Company company)
    {
        throw new NotImplementedException();
    }
}
