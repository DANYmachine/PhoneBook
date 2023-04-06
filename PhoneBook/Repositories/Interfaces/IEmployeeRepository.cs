using PhoneBook.Models;

namespace PhoneBook.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public List<Employee> GetEmployeesByDepartmentId(long departmentId);
    }
}
