using MailTracker.Domain.Entities;

namespace MailTracker.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
    }
}
