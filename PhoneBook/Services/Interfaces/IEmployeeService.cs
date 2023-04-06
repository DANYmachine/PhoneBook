using PhoneBook.Models;

namespace PhoneBook.Services.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        public List<Employee> GetEmployeesByDepartmentId(Guid departmentId);
    }
}
