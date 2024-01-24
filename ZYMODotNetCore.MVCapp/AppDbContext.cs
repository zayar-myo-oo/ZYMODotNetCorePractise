using Microsoft.EntityFrameworkCore;
using ZYMODotNetCore.MVCapp.Models;

namespace ZYMODotNetCore.MVCapp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogDataModel> Blogs { get; set; }

    }
}
