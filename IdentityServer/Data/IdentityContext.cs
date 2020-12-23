using IdentityServer.Data.Entities;
using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; private set; }
        public DbSet<User> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>().Ignore(t => t.IsActive);
        
        }
    }
}
