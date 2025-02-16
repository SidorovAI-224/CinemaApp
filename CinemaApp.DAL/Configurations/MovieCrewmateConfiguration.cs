using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class MovieCrewmateConfiguration : IEntityTypeConfiguration<MovieCrewmate>
    {
        public void Configure(EntityTypeBuilder<MovieCrewmate> builder)
        {
            builder.HasKey(mc => new { MovieID = mc.MovieId, CrewmateID = mc.CrewmateId });

            builder.HasOne(mc => mc.Movie)
                   .WithMany(m => m.MovieCrewmates)
                   .HasForeignKey(mc => mc.MovieId);

            builder.HasOne(mc => mc.Crewmate)
                   .WithMany(c => c.MoviesCrewmates)
                   .HasForeignKey(mc => mc.CrewmateId);
        }
    }
}
