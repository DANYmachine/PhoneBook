using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Models.Exceptions;
using PhoneBook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
            try
            {
                string sqlQuery = "INSERT INTO departments (Name, ParentDepartmentId) " +
                              "VALUES (@Name, @ParentDepartmentId); SELECT LAST_INSERT_ID();";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@ParentDepartmentId", model.ParentDepartmentId);

                long newId = Convert.ToInt64(command.ExecuteScalar());

                return newId;
            }
            catch
            {
                throw new Exception("Error while creating department!");
            }
        }

        public void Delete(long id)
        {
            try
            {
                string sqlQuery = "DELETE FROM departments WHERE Id=@Id";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Error while deleting department!");
            }
        }

        public List<Department> Get()
        {
            try
            {
                string sqlQuery = "SELECT * FROM departments";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Department not found");
                }

                List<Department> list = new List<Department>();

                while (reader.Read())
                {
                    list.Add(new Department()
                    {
                        Id = reader.GetInt64("Id"),
                        Name = reader.GetString("Name"),
                        ParentDepartmentId = reader.GetInt64("ParentDepartmentId")
                    });
                }

                return list;
            }
            catch
            {
                throw new Exception("Error while deleting department!");
            }
        }

        public Department GetById(long id)
        {
            try
            {
                string sqlQuery = "SELECT * FROM departments WHERE Id=@Id";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Department not found");
                }

                reader.Read();

                return new Department()
                {
                    Id = reader.GetInt64("Id"),
                    Name = reader.GetString("Name"),
                    ParentDepartmentId = reader.GetInt64("ParentDepartmentId")
                };
            }
            catch
            {
                throw new Exception("Error while deleting department!");
            }
        }

        public List<Department> GetByQuery(string search)
        {
            try
            {
                string sqlQuery = "SELECT * FROM departments WHERE Name LIKE @Search";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));

                command.Parameters.AddWithValue("@Search", $"%{search}%");

                SqlDataReader reader = command.ExecuteReader();

                List<Department> list = new List<Department>();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Department not found");
                }

                while (reader.Read())
                {
                    list.Add(new Department()
                    {
                        Id = reader.GetInt64("Id"),
                        Name = reader.GetString("Name"),
                        ParentDepartmentId = reader.GetInt64("ParentDepartmentId")
                    });
                }

                return list;
            }
            catch
            {
                throw new Exception("Not found by input!");
            }
        }

        public Department Update(Department model)
        {
            try
            {
                string sqlQuery = "UPDATE departments " +
                                  "SET Name = '@Name', ParentDepartmentId= @ParentDepartmentId" +
                                  $"WHERE Id = {model.Id};";

                SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(_settingsStore.DbConnectionString));
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@ParentDepartmentId", model.ParentDepartmentId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    throw new NotFoundException("Department to update not found");
                }

                reader.Read();

                return new Department()
                {
                    Id = reader.GetInt64("Id"),
                    Name = reader.GetString("Name"),
                    ParentDepartmentId = reader.GetInt64("ParentDepartmentId")
                };
            }
            catch
            {
                throw new Exception("Department update failed!");
            }
        }
    }
}
