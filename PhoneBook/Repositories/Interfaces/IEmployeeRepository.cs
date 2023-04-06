using PhoneBook.Models;

namespace PhoneBook.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public List<Employee> GetEmployeesByDepartmentId(Guid departmentId);
    }
}
