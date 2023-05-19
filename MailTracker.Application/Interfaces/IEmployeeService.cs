using MailTracker.Application.Dto;

namespace MailTracker.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    }
}
