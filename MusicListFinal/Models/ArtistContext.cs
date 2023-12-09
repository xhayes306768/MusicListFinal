using Microsoft.EntityFrameworkCore;

namespace MusicListFinal.Models
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options) : base(options)
        { }

        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Song>()
                .HasKey(s => s.SongId);

            
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    ArtistId = 1,
                    Name = "John Doe",
                    DateOfBirth = new DateTime(1980, 5, 15),
                    AwardsWon = 3
                },
                new Artist
                {
                    ArtistId = 2,
                    Name = "Jane Smith",
                    DateOfBirth = new DateTime(1995, 8, 20),
                    AwardsWon = 1
                }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, ArtistId = 1, Title = "Song1" },
                new Song { SongId = 2, ArtistId = 1, Title = "Song2" },
                new Song { SongId = 3, ArtistId = 1, Title = "Song3" },
                new Song { SongId = 4, ArtistId = 2, Title = "Song4" },
                new Song { SongId = 5, ArtistId = 2, Title = "Song5" }
            );
        }
    }
}
