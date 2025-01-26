using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class CrewmateConfiguration : IEntityTypeConfiguration<Crewmate>
    {
        public void Configure(EntityTypeBuilder<Crewmate> builder)
        {
            builder.HasKey(c => c.CrewmateID);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(c => c.MoviesCrewmates)
                   .WithOne(mc => mc.Crewmate)
                   .HasForeignKey(mc => mc.CrewmateID);

            builder.HasMany(c => c.CrewmatePositions)
                   .WithOne(cp => cp.Crewmate)
                   .HasForeignKey(cp => cp.CrewmateID);
        }
    }
}
