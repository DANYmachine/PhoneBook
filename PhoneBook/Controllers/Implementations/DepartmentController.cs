﻿using Microsoft.AspNetCore.Mvc;
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
        [Route("[action]")]
        public List<Department> Get()
        {
            return _departmentService.Get();
        }

        [HttpGet("[action]/{id:long}")]
        [Route("[action]/{id:long}")]
        public Department Get([FromQuery] long id)
        {
            return _departmentService.GetById(id);
        }

        [HttpGet("[action]/{query}")]
        [Route("[action]/{query}")]
        public List<Department> Get([FromQuery] string query)
        {
            return _departmentService.GetByQuery(query);
        }

        [HttpPost("[action]}")]
        [Route("[action]")]
        public long Post([FromBody] Department model)
        {
            return _departmentService.Create(model);
        }

        [HttpPut("[action]}")]
        [Route("[action]")]
        public Department Put([FromBody] Department model)
        {
            return _departmentService.Update(model);
        }

        [HttpDelete("[action]/{id:long}")]
        [Route("[action]/{id:long}")]
        public void Delete([FromQuery] long id)
        {
            _departmentService.Delete(id);
        }
    }
}
