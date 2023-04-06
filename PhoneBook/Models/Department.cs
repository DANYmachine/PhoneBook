namespace PhoneBook.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public int? ParentDepartmentId { get; set; }
    }
}
