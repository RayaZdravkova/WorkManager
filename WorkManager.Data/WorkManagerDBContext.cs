using Microsoft.EntityFrameworkCore;
using WorkManager.Data.Entities;

namespace WorkManager.Data
{
    public class WorkManagerDBContext : DbContext
    {
        public WorkManagerDBContext(DbContextOptions<WorkManagerDBContext> options)
            :base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Assignee);

            base.OnModelCreating(modelBuilder);
        }
    }
}
