using Microsoft.EntityFrameworkCore;
using DemoWebAPI.Models;

namespace DemoWebAPI.Services
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<User> UserList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(user => user.Email);
            builder.Entity<User>().HasIndex(user => user.Username).IsUnique();
            builder.HasDefaultSchema("public");
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}