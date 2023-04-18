using Newtonsoft.Json;

namespace PhoneBook.Models
{
    public class Department : BaseModel
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public long? ParentDepartmentId { get; set; }
        public List<Department> SubDepartments { get; set; } = new List<Department>();
    }
}
