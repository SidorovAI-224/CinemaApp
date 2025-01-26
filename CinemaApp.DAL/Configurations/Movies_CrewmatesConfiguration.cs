﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class Movies_CrewmatesConfiguration : IEntityTypeConfiguration<Movies_Crewmates>
    {
        public void Configure(EntityTypeBuilder<Movies_Crewmates> builder)
        {
            builder.HasKey(mc => new { mc.MovieID, mc.CrewmateID });

            builder.HasOne(mc => mc.Movie)
                   .WithMany(m => m.MoviesCrewmates)
                   .HasForeignKey(mc => mc.MovieID);

            builder.HasOne(mc => mc.Crewmate)
                   .WithMany(c => c.MoviesCrewmates)
                   .HasForeignKey(mc => mc.CrewmateID);
        }
    }
}
