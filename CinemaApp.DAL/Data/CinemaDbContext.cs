using System;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CinemaApp.DAL.Data
{
    public class CinemaDbContext : IdentityDbContext<User>
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
        
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Crewmate> Crewmates { get; set; }
        public DbSet<MoviesCrewmates> MoviesCrewmates { get; set; }
        public DbSet<CrewmatePositions> CrewmatePositions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<HallOne> Halls { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CrewmateConfiguration());
            modelBuilder.ApplyConfiguration(new Movies_CrewmatesConfiguration());
            modelBuilder.ApplyConfiguration(new Crewmate_PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new HallOneConfiguration());



        }
    }
}
