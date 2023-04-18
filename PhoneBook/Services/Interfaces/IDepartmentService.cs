using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook.Services.Interfaces
{
    public interface IDepartmentService : IBaseService<Department>
    {
        public List<Department> GetChildren(long departmentId);
    }
}
