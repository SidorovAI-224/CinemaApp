using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class HallOneConfiguration : IEntityTypeConfiguration<HallOne>
    {
        public void Configure(EntityTypeBuilder<HallOne> builder)
        {
            builder.HasKey(h => h.SeatID);

            builder.Property(h => h.IsBooked)
                   .IsRequired();

            builder.HasMany(h => h.Tickets)
                   .WithOne(t => t.HallOne)
                   .HasForeignKey(t => t.Seat)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

