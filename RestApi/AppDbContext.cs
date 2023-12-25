using AKLMPSTYZDotNetCore.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace AKLMPSTYZDotNetCore.RestApi
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "AKLMPSTYZDotNetCore",
                UserID = "zayar",
                Password = "admin",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
