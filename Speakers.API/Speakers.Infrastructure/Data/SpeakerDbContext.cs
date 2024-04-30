

using Microsoft.EntityFrameworkCore;
using Speakers.Domain;

namespace Speakers.Infrastructure.Data
{
    public class SpeakerDbContext : DbContext
    {
        public SpeakerDbContext(DbContextOptions<SpeakerDbContext> options) : base(options)
        {

        }
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>().HasData(
                new Speaker { Id = 1, Name = "Türkay", LastName = "Ürkmez" },
                new Speaker { Id = 2, Name = "Burak", LastName = "Ağıt" },
                new Speaker { Id = 3, Name = "Melinda", LastName = "Günebakan" },
                new Speaker { Id = 4, Name = "Melahat", LastName = "Sümbül" },
                new Speaker { Id = 5, Name = "Melike", LastName = "Candan" }
                );



        }
    }
}
