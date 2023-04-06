using PhoneBook.Models;
using PhoneBook.Models.Exceptions;
using PhoneBook.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBook.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppSettingsStore _settingsStore;

        public EmployeeRepository(AppSettingsStore settingsStore)
        {
            _settingsStore = settingsStore;
        }

        public long Create(Employee model)
        {
            try
            {
                string sqlQuery = "INSERT INTO employees (DepartmentId, FirstName, LastName, PhoneNumber, Email) " +
                              "VALUES (@DepartmentId, @FirstName, @LastName, @PhoneNumber, @Email); SELECT LAST_INSERT_ID();";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@Email", model.Email);

                long newId = Convert.ToInt64(command.ExecuteScalar());

                return newId;
            }
            catch
            {
                throw new Exception("Error while adding employee!");
            }
        }

        public void Delete(long id)
        {
            try
            {
                string sqlQuery = "DELETE FROM employees WHERE Id=@Id";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Error while deleting employee!");
            }
        }

        public List<Employee> Get()
        {
            try
            {
                string sqlQuery = "SELECT * FROM employees";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Employees not found");
                }

                List<Employee> list = new List<Employee>();

                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        DepartmentId = reader.GetInt64("DepartmentId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Email = reader.GetString("Email"),
                    });
                }

                return list;
            }
            catch
            {
                throw new Exception("Error while deleting employee!");
            }
        }

        public Employee GetById(long id)
        {
            try
            {
                string sqlQuery = "SELECT * FROM employees WHERE Id=@Id";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Employee not found");
                }

                reader.Read();

                return new Employee()
                {
                    DepartmentId = reader.GetInt64("DepartmentId"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    PhoneNumber = reader.GetString("PhoneNumber"),
                    Email = reader.GetString("Email"),
                };
            }
            catch
            {
                throw new Exception("Employee not found!");
            }
        }

        public List<Employee> GetByQuery(string search)
        {
            try
            {
                string sqlQuery = "SELECT * FROM employees WHERE Name LIKE @Search";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

                command.Parameters.AddWithValue("@Search", $"%{search}%");

                SqlDataReader reader = command.ExecuteReader();

                List<Employee> list = new List<Employee>();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Department not found");
                }

                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        DepartmentId = reader.GetInt64("DepartmentId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Email = reader.GetString("Email"),
                    });
                }

                return list;
            }
            catch
            {
                throw new Exception("Not found by input!");
            }
        }

        public List<Employee> GetEmployeesByDepartmentId(long departmentId)
        {
            try
            {
                string sqlQuery = "SELECT * FROM employees WHERE DepartmentId = @departmentId";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

                command.Parameters.AddWithValue("@departmentId", departmentId);
                SqlDataReader reader = command.ExecuteReader();

                List<Employee> list = new List<Employee>();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Department not found");
                }

                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        DepartmentId = reader.GetInt64("DepartmentId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Email = reader.GetString("Email"),
                    });
                }

                return list;
            }
            catch
            {
                throw new Exception("Not found by Department ID!");
            }
        }

        public Employee Update(Employee model)
        {
            try
            {
                string sqlQuery = "UPDATE employees " +
                                  "SET FirstName = '@FirstName', LastName = '@LastName', DepartmentId = @DepartmentId, PhoneNumber = '@PhoneNumber', Email = '@Email'" +
                                  $"WHERE Id = {model.Id};";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@FirstName", model.Email);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Employee to update not found");
                }

                reader.Read();

                return new Employee()
                {
                    DepartmentId = reader.GetInt64("DepartmentId"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    PhoneNumber = reader.GetString("PhoneNumber"),
                    Email = reader.GetString("Email"),
                };
            }
            catch
            {
                throw new Exception("Employee update failed!");
            }
        }
    }
}
