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

        public long Create(Employee model)
        {
            return _employeeRepository.Create(model);
        }

        public void Delete(long id)
        {
            _employeeRepository.Delete(id);
        }

        public List<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        public Employee GetById(long id)
        {
            return _employeeRepository.GetById(id);
        }

        public List<Employee> GetByQuery(string query)
        {
            return _employeeRepository.GetByQuery(query);
        }

        public List<Employee> GetEmployeesByDepartmentId(long departmentId)
        {
            return _employeeRepository.GetEmployeesByDepartmentId(departmentId);
        }

        public Employee Update(Employee model)
        {
            return _employeeRepository.Update(model);
        }
    }
}
