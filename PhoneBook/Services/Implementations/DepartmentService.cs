using PhoneBook.Models;
using PhoneBook.Repositories.Interfaces;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services.Emplementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        private Dictionary<int, Department> _departmentMap; 

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
            var departments = _departmentRepository.Get();
            var groupByParentId = GroupDepartmentsByParentId(departments);
            var result = departments.FindAll(d => d.ParentDepartmentId == null);
            result.ForEach(d =>
            {
                if (groupByParentId.ContainsKey(d.Id.Value))
                {
                    d.SubDepartments = groupByParentId[d.Id.Value];
                }
            });

            return result;
        }

        public Department GetById(long id)
        {
            var department = _departmentRepository.GetById(id);
            var subDepartments = GroupDepartmentsByParentId(_departmentRepository.GetChildren(id));

            if (subDepartments.ContainsKey(department.Id.Value))
            {
                department.SubDepartments = subDepartments[department.Id.Value];
            }

            return department;
        }

        public List<Department> GetByQuery(string query)
        {
            return _departmentRepository.GetByQuery(query);
        }

        public List<Department> GetChildren(long departmentId)
        {
            return _departmentRepository.GetChildren(departmentId);
        }

        public Department Update(Department model)
        {
            return _departmentRepository.Update(model);
        }

        private Dictionary<long, List<Department>> GroupDepartmentsByParentId(List<Department> departmentList)
        {
            var groupDepartmentsByParentId = new Dictionary<long, List<Department>>();

            foreach (var subDep in departmentList)
            {
                if (subDep.ParentDepartmentId.HasValue)
                {
                    if (!groupDepartmentsByParentId.ContainsKey(subDep.ParentDepartmentId.Value))
                    {
                        groupDepartmentsByParentId.Add(subDep.ParentDepartmentId.Value, new List<Department>());
                    }

                    groupDepartmentsByParentId[subDep.ParentDepartmentId.Value].Add(subDep);
                }
            }

            foreach (var subDep in departmentList)
            {
                if (groupDepartmentsByParentId.ContainsKey(subDep.Id.Value))
                {
                    subDep.SubDepartments = groupDepartmentsByParentId[subDep.Id.Value];
                }
            }

            return groupDepartmentsByParentId;
        }
    }
}
