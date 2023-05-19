using MailTracker.Domain.Entities;

namespace MailTracker.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
