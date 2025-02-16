using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.GenreId);
            builder.Property(g => g.GenreName).IsRequired().HasMaxLength(100);

            builder.HasMany(g => g.Movies)
                   .WithOne(m => m.Genre)
                   .HasForeignKey(m => m.GenreId);
        }
    }
}
