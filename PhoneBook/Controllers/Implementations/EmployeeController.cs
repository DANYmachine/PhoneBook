﻿using Microsoft.AspNetCore.Mvc;
using PhoneBook.Controllers.Interfaces;
using PhoneBook.Models;

namespace PhoneBook.Controllers.Implementations
{
    public class EmployeeController : IBaseController<Employee>
    {
        [HttpGet]
        [Route("[action]")]
        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public Employee Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]/{query}")]
        [Route("[action]/{query}")]
        public List<Employee> Get(string query)
        {
            throw new NotImplementedException();
        }

        [HttpPost("[action]}")]
        [Route("[action]")]
        public Employee Post(Employee model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("[action]}")]
        [Route("[action]")]
        public Employee Put(Employee model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("[action]/{id:guid}")]
        [Route("[action]/{id:guid}")]
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
