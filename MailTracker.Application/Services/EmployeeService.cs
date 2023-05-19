using MailTracker.Application.Interfaces;
using MailTracker.Application.Interfaces.Repositories;
using MailTracker.Domain.Entities;

namespace MailTracker.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }
    }
}
