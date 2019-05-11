using Microsoft.EntityFrameworkCore;
using uts_helps_system.api.Security.Models;
using uts_helps_system.api.Models;
using uts_helps_system.api.ResourceManagement.Models;

namespace uts_helps_system.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) {}
        
        public DbSet<User> UserValues { get; set; }

        public DbSet<UserTokenEntry> UserTokenEntryValues { get; set; }

        public DbSet<UserAccountStatus> UserAccountStatusValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserTokenEntry>().ToTable("UserTokenEntries"); // Security class not considered part of standard model classes
            modelBuilder.Entity<UserAccountStatus>().ToTable("UserAccountStatuses"); // Useful class for user management but is not considered part of standard model classes
        }
    }
}