using PhoneBook.Models;

namespace PhoneBook.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        public List<Department> GetChildren(long departmentId);
    }
}
