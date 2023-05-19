using MailTracker.Application.Interfaces.Repositories;
using MailTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailTracker.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MailDbContext _context;
        public EmployeeRepository(MailDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
