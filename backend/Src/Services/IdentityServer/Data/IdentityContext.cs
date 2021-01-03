using KanbanBoard.Services.IdentityServer.Data.Entities;
using KanbanBoard.Services.IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Services.IdentityServer.Data
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; private set; }

        public DbSet<User> Users { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>()
                .Ignore(t => t.IsActive)
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
