using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class Crewmate_PositionsConfiguration : IEntityTypeConfiguration<CrewmatePositions>
    {
        public void Configure(EntityTypeBuilder<CrewmatePositions> builder)
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
