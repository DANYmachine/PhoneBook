using PhoneBook.Models;

namespace PhoneBook.Controllers.Interfaces
{
    public interface IEmployeeController : IBaseController<Employee>
    {
        public List<Employee> GetDepartmentById(long departmentId);
    }
}
