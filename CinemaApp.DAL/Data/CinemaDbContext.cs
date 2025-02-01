using System;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Configurations;

namespace CinemaApp.DAL.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Crewmate> Crewmates { get; set; }
        public DbSet<MoviesCrewmates> MoviesCrewmates { get; set; }
        public DbSet<CrewmatePositions> CrewmatePositions { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CrewmateConfiguration());
            modelBuilder.ApplyConfiguration(new MoviesCrewmatesConfiguration());
            modelBuilder.ApplyConfiguration(new CrewmatePositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
        }
    }
}
