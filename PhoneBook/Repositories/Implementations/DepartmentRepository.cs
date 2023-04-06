using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;

namespace PhoneBook.Repositories.Implementations
{
    public class DepartmentRepository : IBaseRepository<Department>
    {
        public Department Create(Department model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Department> Get()
        {
            throw new NotImplementedException();
        }

        public Department GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetByQuery(string query)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department model)
        {
            throw new NotImplementedException();
        }
    }
}
