using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.DAL.Configurations
{
    class MovieConfiguration: IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .IsRequired();

            builder.Property(m => m.Genre)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.PremiereDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(m => m.RatingsNumber)
                .HasDefaultValue(0);

            builder.Property(m => m.RatingsSum)
                .HasDefaultValue(0);

            builder.HasOne(m => m.Poster)
                .WithOne(p => p.Movie)
                .HasForeignKey<Poster>(p => p.Id);
            
            builder.HasMany(m => m.Sessions)
                .WithOne(s => s.Movie)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(m => m.Comments)
                .WithOne(c => c.Movie);

            builder.HasOne(m => m.Director)
                .WithMany(d => d.Movies);

            builder.HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(x => x.ToTable("ActorsInMovies"));

            builder.HasMany(m => m.WaitingUsers)
                .WithMany(u => u.ExpectedMovies)
                .UsingEntity(x => x.ToTable("MovieWaitingList"));
        }
    }
}
