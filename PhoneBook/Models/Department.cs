namespace PhoneBook.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public long? ParentDepartmentId { get; set; }
    }
}
