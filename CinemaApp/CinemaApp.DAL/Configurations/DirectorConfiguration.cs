using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CinemaApp.DAL.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.Property(d => d.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
