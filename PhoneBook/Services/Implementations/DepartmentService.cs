using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services.Emplementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

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
