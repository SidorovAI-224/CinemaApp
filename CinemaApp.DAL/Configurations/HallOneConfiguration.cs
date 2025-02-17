using CinemaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.DAL.Configurations
{
    public class HallOneConfiguration : IEntityTypeConfiguration<HallOne>
    {
        public void Configure(EntityTypeBuilder<HallOne> builder)
        {
            // Встановлення складеного первинного ключа
            builder.HasKey(h => new { h.SeatID, h.RowID });

            builder.Property(h => h.IsBooked)
                   .IsRequired();

            // Налаштування зв'язку з Ticket
            builder.HasMany(h => h.Tickets)
                   .WithOne(t => t.HallOne)
                   .HasForeignKey(t => new { t.SeatID, t.RowID }) // Зовнішні ключі
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}