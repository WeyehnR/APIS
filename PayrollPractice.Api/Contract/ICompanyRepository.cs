using PayrollPractice.Api.Models;

namespace PayrollPractice.Api.Contract;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(int id);
    Task<IEnumerable<Company>> GetAllAsync();
    Task AddAsync(Company company);
    void Update(Company company);
    void Delete(Company company);
}
