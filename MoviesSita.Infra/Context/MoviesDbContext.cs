using Microsoft.EntityFrameworkCore;
using MoviesSita.Domain.Entities;
using EFCore.BulkExtensions;
namespace MoviesSita.Infra.Context
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options){}        
        public DbSet<Movies> movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tmdb_movie_dataset_v11");

                entity.Property(e => e.id)
                    .HasColumnName("id");

                entity.Property(e => e.title)
                    .HasColumnName("title")
                    .HasMaxLength(5000);

                entity.Property(e => e.vote_average)
                    .HasColumnName("vote_average");

                entity.Property(e => e.vote_count)
                    .HasColumnName("vote_count");

                entity.Property(e => e.status)
                    .HasColumnName("status");
                
                entity.Property(e => e.release_date)
                    .HasColumnName("release_date");
                
                entity.Property(e => e.revenue)
                    .HasColumnName("revenue");
                
                entity.Property(e => e.runtime)
                    .HasColumnName("runtime");
                
                entity.Property(e => e.adult)
                    .HasColumnName("adult");
                
                entity.Property(e => e.backdrop_path)
                    .HasColumnName("backdrop_path");
                
                entity.Property(e => e.budget)
                    .HasColumnName("budget");
                
                entity.Property(e => e.homepage)
                  .HasColumnName("homepage");
                
                entity.Property(e => e.imdb_id)
                  .HasColumnName("imdb_id");
                
                entity.Property(e => e.original_language)
                  .HasColumnName("original_language");
                
                entity.Property(e => e.original_title)
                  .HasColumnName("original_title");
                
                entity.Property(e => e.overview)
                  .HasColumnName("overview");
                
                entity.Property(e => e.popularity)
                  .HasColumnName("popularity");
                
                entity.Property(e => e.poster_path)
                  .HasColumnName("poster_path");
                
                entity.Property(e => e.tagline)
                  .HasColumnName("tagline");
                
                entity.Property(e => e.genres)
                  .HasColumnName("genres");
                
                entity.Property(e => e.production_companies)
                  .HasColumnName("production_companies");
                
                entity.Property(e => e.production_countries)
                  .HasColumnName("production_countries");
                
                entity.Property(e => e.spoken_languages)
                  .HasColumnName("spoken_languages"); 
                
                entity.Property(e => e.keywords)
                    .HasColumnName("keywords");
            });
        }

    }
}
