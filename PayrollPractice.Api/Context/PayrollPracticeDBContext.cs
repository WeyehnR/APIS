using Microsoft.EntityFrameworkCore;
namespace PayrollPractice.Api.Context;

public class PayrollPracticeDBContext(DbContextOptions<PayrollPracticeDBContext> options) : DbContext(options)
{
}
