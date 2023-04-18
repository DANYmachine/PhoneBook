using Microsoft.AspNetCore.Mvc;
using PhoneBook.Constants;
using PhoneBook.Models;
using PhoneBook.Models.Exceptions;
using PhoneBook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PhoneBook.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppSettingsStore _settingsStore;

        public DepartmentRepository(AppSettingsStore settingsStore)
        {
            _settingsStore = settingsStore;
        }

        public long Create(Department model)
        {
            string sqlQuery = "INSERT INTO departments (Name, ParentDepartmentId) " +
                              $"VALUES (@Name, @ParentDepartmentId); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@ParentDepartmentId", (object?)model.ParentDepartmentId ?? DBNull.Value);
                command.Connection.Open();

                long newId = Convert.ToInt64(command.ExecuteScalar());
                return newId;
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorMessages.CREATE_DEPARTMENT_ERROR);
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public void Delete(long id)
        {
            string sqlQuery = "DELETE FROM departments WHERE Id=@Id";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {             
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception(ErrorMessages.DELETE_DEPARTMENT_ERROR);
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public List<Department> Get()
        {
            string sqlQuery = "SELECT * FROM departments";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {                
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Department> list = new List<Department>();

                while (reader.Read())
                {
                    list.Add(new Department()
                    {
                        Id = reader.GetInt64("Id"),
                        Name = reader.GetString("Name"),
                        ParentDepartmentId = !reader.IsDBNull("ParentDepartmentId") ? reader.GetInt64("ParentDepartmentId") : null
                    });
                }
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorMessages.GET_DEPARTMENTS_ERROR);
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public Department GetById(long id)
        {
            string sqlQuery = $"SELECT * FROM departments WHERE Id=@Id;";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {                
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                var department = new Department()
                {
                    Id = reader.GetInt64("Id"),
                    Name = reader.GetString("Name"),
                    ParentDepartmentId = !reader.IsDBNull("ParentDepartmentId") ? reader.GetInt64("ParentDepartmentId") : null
                };

                return department;
            }
            catch(Exception ex)
            {
                throw new Exception(ErrorMessages.DEPARTMENT_BY_ID_NOT_FOUND_ERROR);
            }
            finally
            {
                if(command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public List<Department> GetByQuery(string search)
        {
            string sqlQuery = $"SELECT * FROM departments WHERE Name LIKE @Search;";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Search", $"%{search}%");
                SqlDataReader reader = command.ExecuteReader();
                List<Department> list = new List<Department>();

                if (!reader.HasRows)
                {
                    throw new NotFoundException(ErrorMessages.DEPARTMENT_NOT_FOUND_BY_QUERY_ERROR);
                }

                while (reader.Read())
                {
                    list.Add(new Department()
                    {
                        Id = reader.GetInt64("Id"),
                        Name = reader.GetString("Name"),
                        ParentDepartmentId = !reader.IsDBNull("ParentDepartmentId") ? reader.GetInt64("ParentDepartmentId") : null
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching for department");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public List<Department> GetChildren(long departmentId)
        {
            string sqlQuery = "WITH Recursive (Id, ParentDepartmentId, [Name])" +
                "AS (SELECT Id, ParentDepartmentId, [Name] FROM departments e WHERE e.ParentDepartmentId = @Id " +
                "UNION ALL SELECT e.Id, e.ParentDepartmentId, e.[Name] " +
                "FROM departments e JOIN Recursive r ON e.ParentDepartmentId = r.Id) SELECT Id, ParentDepartmentId, [Name] " +
                "FROM Recursive r ORDER BY r.Id;";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

            try
            {
                command.Connection.Open();
                command.Parameters.AddWithValue("@Id", departmentId);
                SqlDataReader reader = command.ExecuteReader();
                List<Department> list = new List<Department>();

                while (reader.Read())
                {
                    list.Add(new Department()
                    {
                        Id = reader.GetInt64("Id"),
                        Name = reader.GetString("Name"),
                        ParentDepartmentId = !reader.IsDBNull("ParentDepartmentId") ? reader.GetInt64("ParentDepartmentId") : null
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching for department");
            }
            finally
            {
                if (command.Connection.State is ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public Department Update(Department model)
        {
            string sqlQuery = "UPDATE departments SET Name = @Name, ParentDepartmentId = @ParentDepartmentId WHERE Id = @Id;";
            SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
            command.Parameters.AddWithValue("@Id", model.Id);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@ParentDepartmentId", model.ParentDepartmentId);

            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();

                return model;
            }
            catch(Exception ex)
            {
                throw new Exception("Department update failed!", ex);
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
