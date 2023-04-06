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

        public long Create(Department model)
        {
            return _departmentRepository.Create(model);
        }

        public void Delete(long id)
        {
            _departmentRepository.Delete(id);
        }

        public List<Department> Get()
        {
            return _departmentRepository.Get();
        }

        public Department GetById(long id)
        {
            return _departmentRepository.GetById(id);
        }

        public List<Department> GetByQuery(string query)
        {
            return _departmentRepository.GetByQuery(query);
        }

        public Department Update(Department model)
        {
            return _departmentRepository.Update(model);
        }
    }
}
