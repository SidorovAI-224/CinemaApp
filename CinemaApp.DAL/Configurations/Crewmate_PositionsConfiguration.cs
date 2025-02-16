using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class CrewmatePositionsConfiguration : IEntityTypeConfiguration<CrewmatePositions>
    {
        public void Configure(EntityTypeBuilder<CrewmatePositions> builder)
        {
            builder.HasKey(cp => new { CrewmateID = cp.CrewmateId, PositionID = cp.PositionId });

            builder.HasOne(cp => cp.Crewmate)
                   .WithMany(c => c.CrewmatePositions)
                   .HasForeignKey(cp => cp.CrewmateId);

            builder.HasOne(cp => cp.Position)
                   .WithMany(p => p.CrewmatePositions)
                   .HasForeignKey(cp => cp.PositionId);
        }
    }
}
