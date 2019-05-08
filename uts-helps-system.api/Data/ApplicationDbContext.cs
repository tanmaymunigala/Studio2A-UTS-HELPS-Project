using Microsoft.EntityFrameworkCore;
using uts_helps_system.api.Security.Models;
using uts_helps_system.api.Models;

namespace uts_helps_system.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) {}
        
        public DbSet<Value> Values { get; set; }

        public DbSet<User> UserValues { get; set; }

        public DbSet<UserTokenEntry> UserTokenEntryValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserTokenEntry>().ToTable("UserTokenEntries"); // Security class not considered part of standard model classes
        }
    }
}