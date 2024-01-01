using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKHDotNetCore.ConsoleApp.HomeWork
{
    public class UserAdoDotNet
    {
        private readonly SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-39H7BCS\\MSSQLSERVER02",
            InitialCatalog = "PKHDotNetCore",
            UserID = "sa",
            Password = "admin2762"
        };

        public void Run()
        {
            // Read();
            // Edit(1);
            // Edit(100);
            // Create("Kyaw Kyaw", 25, "Test0002", "Mandalay", "0987654321");
            // Delete(2);
            Update(1, "Phone Khaing Hein edit", 21, "Test0003", "Japan", "1234567890");
        }

        private void Read()
        {
            using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            connection.Open();
            string query = @"SELECT [UserId]
      ,[Username]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[Mobile]
  FROM [dbo].[Table_User]";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["UserId"]} {row["Username"]} {row["Age"]} {row["NRC"]} {row["Address"]} {row["Mobile"]}");
            }
        }

        private void Edit(int id)
        {
            using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            connection.Open();
            string query = @"SELECT [UserId]
      ,[Username]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[Mobile]
  FROM [dbo].[Table_User] where UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine($"User not found");
                return;
            }

            DataRow row = dt.Rows[0];
            Console.WriteLine($"{row["UserId"]} {row["Username"]} {row["Age"]} {row["NRC"]} {row["Address"]} {row["Mobile"]}");
        }

        private void Create(string username, int age, string nrc, string address, string mobile)
        {
            using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Table_User]
           ([Username]
           ,[Age]
           ,[NRC]
           ,[Address]
           ,[Mobile])
     VALUES
           (@Username
           ,@Age
           ,@NRC
           ,@Address
           ,@Mobile)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@NRC", nrc);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Mobile", mobile);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string resultMessage = result > 0 ? "Created Successfully" : "Create Failed";
            Console.WriteLine(resultMessage);
        }

        private void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Table_User]
      WHERE UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserId", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string resultMessage = result > 0 ? "Deleted Successfully" : "Delete Failed";
            Console.WriteLine(resultMessage);
        }

        private void Update(int id, string username, int age, string nrc, string address, string mobile)
        {
            using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Table_User]
                       SET [Username] = @Username
                          ,[Age] = @Age
                          ,[NRC] = @NRC
                          ,[Address] = @Address
                          ,[Mobile] = @Mobile
                         WHERE UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserId", id);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@NRC", nrc);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Mobile", mobile);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string resultMessage = result > 0 ? "Updated Successfully" : "Update Failed";
            Console.WriteLine(resultMessage);
        }
    }
}
