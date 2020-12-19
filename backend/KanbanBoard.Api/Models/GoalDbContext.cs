using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace KanbanBoard.Api.Models
{
    public class GoalDbContext : IdentityDbContext
    {
        public GoalDbContext(DbContextOptions<GoalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Goal>()
                .HasOne<AppUser>()
                .WithMany();
        }

        public DbSet<Goal> Goals { get; set; }
    }
}
