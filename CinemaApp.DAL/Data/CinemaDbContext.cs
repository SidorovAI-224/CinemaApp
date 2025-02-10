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

        public DbSet<HallOne> Halls { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Crewmate> Crewmates { get; set; }
        public DbSet<Movies_Crewmates> MoviesCrewmates { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Crewmate_Positions> CrewmatePositions { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new HallOneConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CrewmateConfiguration());
            modelBuilder.ApplyConfiguration(new Movies_CrewmatesConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new Crewmate_PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());

         
        }
    }
}
