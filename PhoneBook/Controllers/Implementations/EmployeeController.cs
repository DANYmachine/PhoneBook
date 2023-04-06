using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Interfaces;
using PhoneBook.Models;
using PhoneBook.Repositories.Implementations;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook.Controllers.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller, IBaseController<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public Employee Get([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{query}")]
        [Route("[action]/{query}")]
        public List<Employee> Get([FromQuery] string query)
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]}")]
        [Route("[action]")]
        public Employee Post([FromBody] Employee model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]}")]
        [Route("[action]")]
        public Employee Put([FromBody] Employee model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public void Delete([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
