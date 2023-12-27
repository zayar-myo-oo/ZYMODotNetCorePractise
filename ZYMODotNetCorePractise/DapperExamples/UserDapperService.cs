using Dapper;
using System.Data;
using System.Data.SqlClient;
using ZYMODotNetCorePractise.Models;

namespace ConsoleApp.DapperExamples
{
    public class UserDapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "AKLMPSTYZDotNetCore",
            UserID = "zayar",
            Password = "admin"
        };

        public void Run()
        {
            CheckSQLConnection();

        }
        private void CheckSQLConnection()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                try
                {
                    db.Open();
                    Console.WriteLine("Connection successful!");
                    db.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to the database");
                }
            }
        }
        private void Read()
        {
            string query = @"SELECT [User_id]
      ,[User_name]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[Mobile_no]
  FROM [dbo].[Tbl_User]";
            Console.Write("Connection is " + _sqlConnectionStringBuilder);
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogDataUser> lst = db.Query<BlogDataUser>(query).ToList();
            foreach (BlogDataUser item in lst)
            {
                Console.WriteLine(item.User_id);
                Console.WriteLine(item.User_name);
                Console.WriteLine(item.User_age);
                Console.WriteLine(item.User_nrc);
                Console.WriteLine(item.User_address);
                Console.WriteLine(item.Mobile_no);
            }
        }

        private void Edit(int id)
        {
            string query = @"SELECT [User_id]
      ,[User_name]
      ,[Age]
      ,[NRC]
      ,[Address]
      ,[Mobile_no]
       FROM [dbo].[Tbl_User] WHERE User_id = @User_id";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            BlogDataUser item = db.Query<BlogDataUser>(query, new { UserId = id }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.User_id);
            Console.WriteLine(item.User_name);
            Console.WriteLine(item.User_age);
            Console.WriteLine(item.User_nrc);
            Console.WriteLine(item.User_address);
            Console.WriteLine(item.Mobile_no);
        }

        private void Create(string userName, int age, string nrc, string address, int mobileNo)
        {
            string query = @"INSERT INTO [dbo].[Tbl_User]
           ([User_name]
           ,[Age]
           ,[NRC]
           ,[Address]
           ,[Mobile_no])
            VALUES (@User_name, @Age, @NRC, @Address, @Mobile_no)";

            BlogDataUser user = new BlogDataUser()
            {
                User_name = userName,
                User_age = age,
                User_nrc = nrc,
                User_address = address,
                Mobile_no = mobileNo
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, user);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        // Similar adjustments for Update and Delete methods...
    }

}