using Microsoft.EntityFrameworkCore;

namespace MusicListFinal.Models
{
    public class MusicContext:DbContext 
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        { }
        public DbSet<Music> Movies { get; set; } = null!;


    }
}
