using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Interfaces;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Controllers.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller, IDepartmentController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public List<Department> Get()
        {
            return _departmentService.Get();
        }

        [HttpGet]
        [Route("{id:long}")]
        public Department Get([FromRoute] long id)
        {
            return _departmentService.GetById(id);
        }

        [HttpGet]
        [Route("{query}")]
        public List<Department> Get([FromRoute] string query)
        {
            return _departmentService.GetByQuery(query);
        }

        [HttpPost]
        public long Post([FromBody] Department model)
        {
            return _departmentService.Create(model);
        }

        [HttpPut]
        public Department Put([FromBody] Department model)
        {
            return _departmentService.Update(model);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public void Delete([FromRoute] long id)
        {
            _departmentService.Delete(id);
        }
    }
}
