using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class Crewmate_PositionsConfiguration : IEntityTypeConfiguration<Crewmate_Positions>
    {
        public void Configure(EntityTypeBuilder<Crewmate_Positions> builder)
        {
            builder.HasKey(cp => new { cp.CrewmateID, cp.PositionID });

            builder.HasOne(cp => cp.Crewmate)
                   .WithMany(c => c.CrewmatePositions)
                   .HasForeignKey(cp => cp.CrewmateID);

            builder.HasOne(cp => cp.Position)
                   .WithMany(p => p.CrewmatePositions)
                   .HasForeignKey(cp => cp.PositionID);
        }
    }
}
