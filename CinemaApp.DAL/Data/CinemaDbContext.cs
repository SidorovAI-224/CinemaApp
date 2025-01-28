using System;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CinemaApp.DAL.Data
{
    public class CinemaDbContext : IdentityDbContext<IdentityUser> //DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Crewmate> Crewmates { get; set; }
        public DbSet<Movies_Crewmates> MoviesCrewmates { get; set; }
        public DbSet<Crewmate_Positions> CrewmatePositions { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CrewmateConfiguration());
            modelBuilder.ApplyConfiguration(new Movies_CrewmatesConfiguration());
            modelBuilder.ApplyConfiguration(new Crewmate_PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());

            string adminName = "admin";
            string roleAdminId = "407BF8AF-8CE1-45E1-9F2A-2270E884ED28"; //Guid.NewGuid().ToString(); ?
            string userAdminId = "433D71D7-3843-4EF9-B934-5177D755F545";

            //Добавляємо роль адміністратора сайту
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            //Добавляємо нового IdentityUser в якості адміністратора сайту
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminName),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            //Визначаємо адміна на відповідну роль
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });
        }
    }
}
