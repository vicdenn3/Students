using Microsoft.EntityFrameworkCore;
using Students.Model;

namespace Students.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            optionsBuilder.UseSqlServer(DatabaseConfig.ConnectionString);
        }
    }
}