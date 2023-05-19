using MailTracker.DataAccess.Configurations;
using MailTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailTracker.DataAccess
{
    public class MailDbContext : DbContext
    {
        public MailDbContext(DbContextOptions<MailDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmailConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        }
    }






}
