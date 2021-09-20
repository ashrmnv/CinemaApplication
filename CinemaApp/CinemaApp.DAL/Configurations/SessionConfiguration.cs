using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.DAL.Configurations
{
    class SessionConfiguration : IEntityTypeConfiguration<Session>
    { 
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.DateTime)
                .HasColumnType("smalldatetime");

            builder.Property(s => s.MovieId)
                .IsRequired(false);

            builder.HasMany(s => s.Tickets)
                .WithOne(t => t.Session);
        }
    }
}
