using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.DAL.Configurations
{
    public class RatedMoviesConfiguration : IEntityTypeConfiguration<RatedMovies>
    {
        public void Configure(EntityTypeBuilder<RatedMovies> builder)
        {
            builder.HasKey(x => new { x.UserId, x.MovieId });

            builder.Property(x => x.Rating)
                .IsRequired();
        }
    }
}
