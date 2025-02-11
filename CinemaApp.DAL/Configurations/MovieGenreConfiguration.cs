using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.MovieID, mg.GenreID });

            builder.HasOne(mg => mg.Movie);
            //.WithMany(m => m.MovieGenre)
            //.HasForeignKey(mg => mg.MovieID);

            builder.HasOne(mg => mg.Genre);
                   //.WithMany(g => g.MovieGenre)
                   //.HasForeignKey(mg => mg.GenreID);
        }
    }
}

