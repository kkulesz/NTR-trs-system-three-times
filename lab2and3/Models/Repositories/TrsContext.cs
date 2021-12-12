using Microsoft.EntityFrameworkCore;

namespace lab2and3.Models.Repositories
{
    public class TrsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=NTR;user=NTR;password=123456789");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}