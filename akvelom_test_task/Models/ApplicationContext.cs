using Microsoft.EntityFrameworkCore;

namespace akvelom_test_task.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MyProject> MyProjects { get; set; }
        public DbSet<MyTask> Tasks { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyProject>().ToTable("MyProject");
            modelBuilder.Entity<MyTask>().ToTable("MyTask");
        }
    }
}