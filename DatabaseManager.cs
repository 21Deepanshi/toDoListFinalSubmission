using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace FinalProject_RAD
{
    public class DatabaseManager
    {
        private string connectionString = "Data Source= LAPTOPD\\SQLEXPRESS; Initial Catalog= ToDoTasks; Integrated Security = True";

        // Add a new task to the database
        public void AddTask(TaskItem task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tasks (Description, Category, StartDate, EndDate, Status) " +
                               "VALUES (@Description, @Category, @StartDate, @EndDate, @Status)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = task.Description;
                command.Parameters.Add("@Category", SqlDbType.NVarChar).Value = task.Category;
                command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = task.StartDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = task.EndDate;
                command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = task.Status;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Handle exception or log it
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Delete a task from the database by Id
        public void DeleteTask(int taskId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tasks WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", taskId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateTask(TaskItem task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tasks SET Description = @Description, Category = @Category, " +
                               "StartDate = @StartDate, EndDate = @EndDate, Status = @Status WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.AddWithValue("@Category", task.Category);
                command.Parameters.AddWithValue("@StartDate", task.StartDate);
                command.Parameters.AddWithValue("@EndDate", task.EndDate);
                command.Parameters.AddWithValue("@Status", task.Status);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Fetch all tasks from the database
        public List<TaskItem> GetTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Description, Category, StartDate, EndDate, Status FROM Tasks";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TaskItem task = new TaskItem
                    {
                        Id = (int)reader["Id"],
                        Description = reader["Description"].ToString(),
                        Category = reader["Category"].ToString(),
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"],
                        Status = reader["Status"].ToString()
                    };

                    tasks.Add(task);
                }

                connection.Close();
            }

            return tasks;
        }
    }
}
