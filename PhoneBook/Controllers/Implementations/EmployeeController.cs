using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Interfaces;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Controllers.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller, IEmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Employee> Get()
        {
            return _employeeService.Get();
        }

        [HttpGet("[action]/{id:long}")]
        [Route("[action]/{id:long}")]
        public Employee Get([FromRoute] long id)
        {
            return _employeeService.GetById(id);
        }

        [HttpGet("[action]/{query}")]
        [Route("[action]/{query}")]
        public List<Employee> Get([FromRoute] string query)
        {
            return _employeeService.GetByQuery(query);
        }

        [HttpPost("[action]}")]
        [Route("[action]")]
        public long Post([FromBody] Employee model)
        {
            return _employeeService.Create(model);
        }

        [HttpPut("[action]}")]
        [Route("[action]")]
        public Employee Put([FromBody] Employee model)
        {
            return _employeeService.Update(model);
        }

        [HttpDelete("[action]/{id:long}")]
        [Route("[action]/{id:long}")]
        public void Delete([FromRoute] long id)
        {
            _employeeService.Delete(id);
        }

        //api.com/Employee/Department/1
        [HttpGet("[action]/Department/{departmentId:long}")]
        [Route("[action]/Department/{departmentId:long}")]
        public List<Employee> GetDepartmentById([FromRoute] long departmentId)
        {
            return _employeeService.GetEmployeesByDepartmentId(departmentId);
        }
    }
}
