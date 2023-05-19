using MailTracker.Application.Interfaces;
using MailTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MailTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAsync()
        {
            var response = await _employeeService.GetAllEmployeesAsync();
            return Ok(response);
        }
    }
}
