using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Interfaces;
using PhoneBook.Models;
using PhoneBook.Repositories.Implementations;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook.Controllers.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller, IEmployeeController
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
        public Employee Get([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{query}")]
        [Route("[action]/{query}")]
        public List<Employee> Get([FromRoute] string query)
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
        public void Delete([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        //api.com/Employee/Department/1
        [HttpGet("[action]/Department/{departmentId:guid}")]
        [Route("[action]/Department/{departmentId:guid}")]
        public List<Employee> GetDepartmentById([FromRoute] Guid departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
