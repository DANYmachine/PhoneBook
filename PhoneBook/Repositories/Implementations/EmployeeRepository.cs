using PhoneBook.Models;
using PhoneBook.Models.Exceptions;
using PhoneBook.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            string sqlQuery = "INSERT INTO employees (DepartmentId, FirstName, LastName, PhoneNumber, Email) " +
                              "VALUES (@DepartmentId, @FirstName, @LastName, @PhoneNumber, @Email); SELECT LAST_INSERT_ID();";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {                
                command.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@Email", (object?)model.Email ?? DBNull.Value);
                command.Connection.Open();

                long newId = Convert.ToInt64(command.ExecuteScalar());

                return newId;
            }
            catch
            {
                throw new Exception("Error while adding employee!");
            }
            finally
            {
                if(command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public void Delete(long id)
        {
            string sqlQuery = "DELETE FROM employees WHERE Id=@Id";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Error while deleting employee!");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public List<Employee> Get()
        {
            string sqlQuery = "SELECT * FROM employees";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Employee> list = new List<Employee>();

                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = reader.GetInt64("Id"),
                        DepartmentId = reader.GetInt64("DepartmentId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Email = reader.GetString("Email"),
                    });
                }

                return list;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while deleting employee!");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public Employee GetById(long id)
        {
            string sqlQuery = $"SELECT * FROM employees WHERE Id={id}";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {                
                command.Connection.Open();
                //command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new NotFoundException("Employee not found");
                }

                reader.Read();

                return new Employee()
                {
                    Id = reader.GetInt64("Id"),
                    DepartmentId = reader.GetInt64("DepartmentId"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    PhoneNumber = reader.GetString("PhoneNumber"),
                    Email = reader.GetString("Email"),
                };
            }
            catch(Exception ex)
            {
                throw new Exception("Employee not found!");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public List<Employee> GetByQuery(string search)
        {
            string sqlQuery = "SELECT * FROM employees WHERE FirstName LIKE @Search;";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Parameters.AddWithValue("@Search", $"%{search}%");
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Employee> list = new List<Employee>();

                if (!reader.HasRows)
                {
                    throw new NotFoundException("Employee not found");
                }

                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = reader.GetInt64("Id"),
                        DepartmentId = reader.GetInt64("DepartmentId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        PhoneNumber = reader.GetString("PhoneNumber"),
                        Email = reader.GetString("Email"),
                    });
                }

                return list;
            }
            catch(Exception ex)
            {
                throw new Exception("Not found by input!");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public List<Employee> GetEmployeesByDepartmentId(long departmentId)
        {
            string sqlQuery = "SELECT * FROM employees WHERE DepartmentId = @departmentId";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@departmentId", departmentId);
                SqlDataReader reader = command.ExecuteReader();
                List<Employee> list = new List<Employee>();

                if (!reader.HasRows)
                {
                    throw new NotFoundException("Department not found");
                }

                while (reader.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = reader.GetInt64("Id"),
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
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public Employee Update(Employee model)
        {
            string sqlQuery = "UPDATE employees " +
                                  "SET FirstName = @FirstName, LastName = @LastName, DepartmentId = @DepartmentId, PhoneNumber = @PhoneNumber, Email = @Email" +
                                  $"WHERE Id = {model.Id};";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@DepartmentId", model.DepartmentId);
                command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                command.Parameters.AddWithValue("@FirstName", model.Email);

                command.ExecuteNonQuery();

                return model;
            }
            catch
            {
                throw new Exception("Employee update failed!");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }
    }
}
