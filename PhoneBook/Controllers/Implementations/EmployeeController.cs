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

        [HttpGet("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public Employee Get([FromRoute] Guid id)
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
        public Employee Post([FromBody] Employee model)
        {
            return _employeeService.Create(model);
        }

        [HttpPut("[action]}")]
        [Route("[action]")]
        public Employee Put([FromBody] Employee model)
        {
            return _employeeService.Update(model);
        }

        [HttpDelete("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public void Delete([FromRoute] Guid id)
        {
            _employeeService.Delete(id);
        }

        //api.com/Employee/Department/1
        [HttpGet("[action]/Department/{departmentId:guid}")]
        [Route("[action]/Department/{departmentId:guid}")]
        public List<Employee> GetDepartmentById([FromRoute] Guid departmentId)
        {
            return _employeeService.GetEmployeesByDepartmentId(departmentId);
        }
    }
}
