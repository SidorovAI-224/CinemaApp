using System;
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

            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreID);

            builder.HasMany(m => m.Sessions)
                   .WithOne(s => s.Movie)
                   .HasForeignKey(s => s.MovieID);
        }
    }
}
