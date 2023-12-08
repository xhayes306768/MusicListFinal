using Microsoft.EntityFrameworkCore;

namespace MusicListFinal.Models
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options) : base(options)
        { }

        public DbSet<Artist> Artists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  initial data 
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    ArtistId = 1,
                    Name = "John Doe",
                    DateOfBirth = new DateTime(1980, 5, 15),
                    Songs = new List<string> { "Song1", "Song2", "Song3" },
                    AwardsWon = 3
                },
                new Artist
                {
                    ArtistId = 2,
                    Name = "Jane Smith",
                    DateOfBirth = new DateTime(1995, 8, 20),
                    Songs = new List<string> { "Song4", "Song5" },
                    AwardsWon = 1
                }
               
            );
        }
    }
}
