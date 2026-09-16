using Microsoft.EntityFrameworkCore;
using SocialMedia.DAL.Entities;

namespace SocialMedia.DAL.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyDatabaseEmployee;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=true;");
        }

        public DbSet<Entities.Employee> Employees { get; set; }
    }
}
