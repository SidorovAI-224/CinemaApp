using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.SessionID);

            builder.Property(s => s.StartTime)
                   .IsRequired();

            builder.Property(s => s.Date)
                   .IsRequired();

            builder.Property(s => s.Hall)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(s => s.Movie)
                   .WithMany(m => m.Sessions)
                   .HasForeignKey(s => s.MovieID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
