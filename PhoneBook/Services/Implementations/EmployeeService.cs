using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services.Emplementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Create(Employee model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByDepartmentId(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
