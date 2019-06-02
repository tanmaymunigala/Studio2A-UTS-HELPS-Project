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

        public DbSet<Student> StudentValues { get; set; }

        public DbSet<Admin> AdminValues { get; set; }

        public DbSet<Workshop> WorkshopValues { get; set; }

        public DbSet<Booking> BookingValues { get; set; }


        public DbSet<UserTokenEntry> UserTokenEntryValues { get; set; }

        public DbSet<UserAccountStatus> UserAccountStatusValues { get; set; }

        public DbSet<RegisteredAdminEmail> RegisteredAdminEmailValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Workshop>().ToTable("Workshops");
            modelBuilder.Entity<Booking>().ToTable("Bookings");
            modelBuilder.Entity<UserTokenEntry>().ToTable("UserTokenEntries"); // Security class not considered part of standard model classes
            modelBuilder.Entity<UserAccountStatus>().ToTable("UserAccountStatuses"); // Useful class for user management but is not considered part of standard model classes
            modelBuilder.Entity<RegisteredAdminEmail>().ToTable("RegisteredAdminEmails"); // Useful for storing all the emails that have been pre-approved for becoming admins
        }
    }
}