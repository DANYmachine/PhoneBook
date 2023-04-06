namespace PhoneBook.Models
{
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long DepartmentId { get; set; }
        public string Telephone { get; set; }
    }
}
