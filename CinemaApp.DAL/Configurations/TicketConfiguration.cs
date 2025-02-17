using CinemaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.DAL.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.TicketID);

            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.BookingDate).IsRequired();

            builder.HasOne(t => t.Session)
                   .WithMany(s => s.Tickets)
                   .HasForeignKey(t => t.SessionID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.HallOne) ////
                .WithMany(h => h.Tickets)
                .HasForeignKey(t => new { t.SeatID, t.RowID })
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.User)
                   .WithMany(u => u.Tickets)
                   .HasForeignKey(t => t.UserID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}