using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook.Repositories.Implementations
{
    public class EmployeeRepository : IBaseRepository<Employee>
    {
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

        public Employee Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
