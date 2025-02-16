using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.MovieID);
            builder.Property(m => m.Title).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Description).HasMaxLength(1000);
            builder.Property(m => m.PosterURL).HasMaxLength(500);
            builder.Property(m => m.TrailerURL).HasMaxLength(500);

            builder.HasOne(m => m.Genre1)
                   .WithMany()
                   .HasForeignKey(m => m.GenreID1)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Genre2)
                   .WithMany()
                   .HasForeignKey(m => m.GenreID2)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Genre3)
                   .WithMany()
                   .HasForeignKey(m => m.GenreID3)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Genre4)
                   .WithMany()
                   .HasForeignKey(m => m.GenreID4)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Sessions)
                   .WithOne(s => s.Movie)
                   .HasForeignKey(s => s.MovieID);
        }
    }
}
