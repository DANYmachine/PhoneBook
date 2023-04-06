using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public long Create(Employee model)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByDepartmentId(long departmentId)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
