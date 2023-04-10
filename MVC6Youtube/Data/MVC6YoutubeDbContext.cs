using Microsoft.EntityFrameworkCore;
using MVC6Youtube.Models;

namespace MVC6Youtube.Data
{
    public class MVC6YoutubeDbContext : DbContext
    {
        public MVC6YoutubeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
