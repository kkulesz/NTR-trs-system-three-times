using Microsoft.EntityFrameworkCore;

using lab2and3.Models.DomainModel;

namespace lab2and3.Models.Repositories
{
    public class TrsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UsersMonth> UsersMonths { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=NTR;user=NTR;password=123456789");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.HasKey(e => e.UserId);
            // });

            modelBuilder.Entity<UsersMonth>(entity =>
            {
                entity.HasKey(e => new { e.UserLogin, e.Month, e.Year });
                // entity.Property(e => e.User).IsRequired();
                // entity.Property(e => e.Month).IsRequired();
                // entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Frozen); //todo: IsRequired?
            });

            // modelBuilder.Entity<Project>(entity =>
            // {
            //     entity.HasKey(e => e.ProjectId);
            //     entity.Property(e => e.Budget);
            //     entity.Property(e => e.IsActive);
            //     entity.Property(e => e.User);
            //     entity.Property(e => e.Users);
            //     entity.Property(e => e.Categories);
            // });

            // modelBuilder.Entity<Activity>(entity =>
            // {
            //     entity.HasKey(e => e.ActivityId);
            //     entity.Property(e => e.AcceptedBudget);
            //     entity.Property(e => e.Budget).IsRequired();
            //     entity.Property(e => e.Date).IsRequired();
            //     entity.Property(e => e.Description);
            //     entity.Property(e => e.IsActive);
            //     entity.Property(e => e.Project);
            //     entity.Property(e => e.Subactivities);
            //     entity.Property(e => e.User);
            // });
        }
    }
}