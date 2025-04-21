using Microsoft.EntityFrameworkCore;
using MoviesSita.Domain.Entities;
namespace MoviesSita.Infra.Context
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options){}        
        public DbSet<Movies> movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesDbContext).Assembly);
        }
    }
}
