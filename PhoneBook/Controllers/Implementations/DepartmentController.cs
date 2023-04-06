﻿using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Interfaces;
using PhoneBook.Models;
using PhoneBook.Repositories.Implementations;
using PhoneBook.Repositories.Interfaces;
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
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public Department Get([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{query}")]
        [Route("[action]/{query}")]
        public List<Department> Get([FromQuery] string query)
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]}")]
        [Route("[action]")]
        public Department Post([FromBody] Department model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]}")]
        [Route("[action]")]
        public Department Put([FromBody] Department model)
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
