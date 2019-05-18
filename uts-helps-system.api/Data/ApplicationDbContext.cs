using Microsoft.EntityFrameworkCore;
using uts_helps_system.api.Models;

namespace uts_helps_system.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) {}
        
        public DbSet<Value> Values { get; set; }
    }
}