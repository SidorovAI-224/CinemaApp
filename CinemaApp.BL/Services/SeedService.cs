using CinemaApp.DAL.Data;
using CinemaApp.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CinemaApp.BL.Services
{
    public class SeedService
    {
        private readonly CinemaDbContext _context;
        private readonly OMDbService _omDbService;
        private readonly Random _random;

        public SeedService(CinemaDbContext context, OMDbService omDbService)
        {
            _context = context;
            _omDbService = omDbService;
            _random = new Random();
        }

        private async Task AddGenresAsync()
        {
            if (!await _context.Genres.AnyAsync())
            {
                var genres = new List<Genre>
            {
                new Genre { GenreName = "Action" },
                new Genre { GenreName = "Comedy" },
                new Genre { GenreName = "Drama" },
                new Genre { GenreName = "Horror" },
                new Genre { GenreName = "Sci-Fi" },
                new Genre { GenreName = "Thriller" },
                new Genre { GenreName = "Romance" },
                new Genre { GenreName = "Adventure" },
                new Genre { GenreName = "Animation" },
                new Genre { GenreName = "Documentary" }
            };

                _context.Genres.AddRange(genres);
                await _context.SaveChangesAsync();
            }
        }

        private async Task AddActorsAndPositionsAsync()
        {
            if (!await _context.Crewmates.AnyAsync())
            {
                var actors = new List<Crewmate>
                {
                    new Crewmate { Name = "John Doe" },
                    new Crewmate { Name = "Jane Smith" },
                    new Crewmate { Name = "Chris Evans" },
                    new Crewmate { Name = "Scarlett Johansson" }
                };

                _context.Crewmates.AddRange(actors);
                await _context.SaveChangesAsync();
            }

            if (!await _context.Positions.AnyAsync())
            {
                var positions = new List<Position>
                {
                    new Position { PositionName = "Lead" },
                    new Position { PositionName = "Supporting" },
                    new Position { PositionName = "Director" }
                };

                _context.Positions.AddRange(positions);
                await _context.SaveChangesAsync();
            }
        }
        private async Task<Genre> GetRandomGenreAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres[_random.Next(genres.Count)];
        }

        public async Task SeedRandomMoviesAsync(int count = 100)
        {
            try
            {
                await AddGenresAsync();

                for (int i = 0; i < count; i++)
                {
                    var randomMovie = await _omDbService.GetRandomMovieAsync();
                    if (randomMovie == null)
                    {
                        Console.WriteLine("Failed to fetch a random movie from OMDb API.");
                        continue;
                    }

                    if (await _context.Movies.AnyAsync(m => m.Title == randomMovie.Title && m.ReleaseDate == randomMovie.ReleaseDate))
                    {
                        Console.WriteLine($"Movie '{randomMovie.Title}' already exists in the database.");
                        continue;
                    }

                    var randomGenre = await GetRandomGenreAsync();
                    randomMovie.Genre = randomGenre;
                    randomMovie.GenreID = randomGenre.GenreID;

                    _context.Movies.Add(randomMovie);
                    await _context.SaveChangesAsync();

                    Console.WriteLine($"Added movie: {randomMovie.Title} with genre: {randomGenre.GenreName}");
                }

                Console.WriteLine($"{count} random movies seeded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while seeding random movies: {ex.Message}");
            }
        }

        public async Task SeedMoviesAsync()
        {
            try
            {
                await AddGenresAsync();
                await AddActorsAndPositionsAsync();

                var movies = await _omDbService.GetPopularMoviesAsync();
                if (movies != null && movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        if (!await _context.Movies.AnyAsync(m => m.Title == movie.Title && m.ReleaseDate == movie.ReleaseDate))
                        {
                            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.GenreName == "Drama");
                            if (genre != null)
                            {
                                movie.Genre = genre;
                                movie.GenreID = genre.GenreID;
                            }

                            var actor1 = await _context.Crewmates.FirstOrDefaultAsync(a => a.Name == "John Doe");
                            var position1 = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == "Lead");

                            var actor2 = await _context.Crewmates.FirstOrDefaultAsync(a => a.Name == "Jane Smith");
                            var position2 = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == "Supporting");

                            if (actor1 != null && position1 != null && actor2 != null && position2 != null)
                            {
                                movie.MovieCrewmates = new List<MovieCrewmate>
                        {
                            new MovieCrewmate
                            {
                                CrewmateID = actor1.CrewmateID,
                                PositionID = position1.PositionID
                            },
                            new MovieCrewmate
                            {
                                CrewmateID = actor2.CrewmateID,
                                PositionID = position2.PositionID
                            }
                        };
                            }
                            else
                            {
                                Console.WriteLine("One or more actors or positions not found in the database.");
                            }

                            _context.Movies.Add(movie);
                        }
                    }
                    await _context.SaveChangesAsync();
                    Console.WriteLine($"{movies.Count} movies seeded successfully.");
                }
                else
                {
                    Console.WriteLine("No movies found to seed.");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        // - - - - - - - - - Dima 

        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Ensure the database is created.");
                await context.Database.EnsureCreatedAsync();

                logger.LogInformation("Seeding roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                logger.LogInformation("Seeding admin user.");
                var adminEmail = "admin@codehub.com";

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new User()
                    {
                        FullName = "Comand Number Seventeen",
                        Age = 35,
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        RegistrationDate = DateTime.UtcNow
                    };
                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database");
            }
        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(",", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
